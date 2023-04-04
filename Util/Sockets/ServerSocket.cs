using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Util
{
    public class ServerSocket
    {
        #region [Privados]

        private const string ENDOFMESSAGE = "ENDOFMESSAGE";

        #endregion

        #region [Eventos]
        public delegate void ServerSocket_Delegate(EventData data);
        public event ServerSocket_Delegate ServerSocket_Event;

        #endregion [Eventos]

        public AsyncCallback pfnWorkerCallBack;
        private Socket m_mainSocket;

        // An ArrayList is used to keep track of worker sockets that are designed
        // to communicate with each connected client. Make it a synchronized ArrayList
        // For thread safety
        private System.Collections.ArrayList m_workerSocketList = ArrayList.Synchronized(new System.Collections.ArrayList());

        // The following variable will keep track of the cumulative 
        // total number of clients connected at any time. Since multiple threads
        // can access this variable, modifying this variable should be done
        // in a thread safe manner
        private int m_clientCount = 0;

        public void StartListeningSocket(int port)
        {
            try
            {
                string portStr = GetIP();                
                // Create the listening socket...
                m_mainSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
                IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, port);
                // Bind to local IP Address...
                m_mainSocket.Bind(ipLocal);
                // Start listening...
                m_mainSocket.Listen(4);
                // Create the call back for any client connections...
                m_mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);

                //UpdateControls(true);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // This is the call back function, which will be invoked when a client is connected
        public void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                // Here we complete/end the BeginAccept() asynchronous call
                // by calling EndAccept() - which returns the reference to
                // a new Socket object
                Socket workerSocket = m_mainSocket.EndAccept(asyn);

                // Now increment the client count for this client 
                // in a thread safe manner
                Interlocked.Increment(ref m_clientCount);

                // Add the workerSocket reference to our ArrayList
                m_workerSocketList.Add(workerSocket);

                // Update the list box showing the list of clients (thread safe call)
                //UpdateClientListControl();

                // Let the worker Socket do the further processing for the 
                // just connected client
                WaitForData(workerSocket, m_clientCount);

                // Since the main Socket is now free, it can go back and wait for
                // other clients who are attempting to connect
                m_mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
            }

        }

        public class SocketPacket
        {
            // Constructor which takes a Socket and a client number
            public SocketPacket(System.Net.Sockets.Socket socket, int clientNumber)
            {
                m_currentSocket = socket;
                m_clientNumber = clientNumber;
            }
            public System.Net.Sockets.Socket m_currentSocket;
            public int m_clientNumber;
            // Buffer to store the data sent by the client
            public byte[] dataBuffer = new byte[1024];
        }
        // Start waiting for data from the client
        public void WaitForData(System.Net.Sockets.Socket soc, int clientNumber)
        {
            try
            {
                if (pfnWorkerCallBack == null)
                {
                    // Specify the call back function which is to be 
                    // invoked when there is any write activity by the 
                    // connected client
                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket(soc, clientNumber);

                soc.BeginReceive(theSocPkt.dataBuffer, 0,
                    theSocPkt.dataBuffer.Length,
                    SocketFlags.None,
                    pfnWorkerCallBack,
                    theSocPkt);
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
            }
        }
        // This the call back function which will be invoked when the socket
        // detects any client writing of data on the stream
        public void OnDataReceived(IAsyncResult asyn)
        {
            SocketPacket socketData = (SocketPacket)asyn.AsyncState;
            try
            {
                // Complete the BeginReceive() asynchronous call by EndReceive() method
                // which will return the number of characters written to the stream 
                // by the client
                int iRx = socketData.m_currentSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                // Extract the characters as a buffer
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(socketData.dataBuffer, 0, iRx, chars, 0);

                System.String szData = new System.String(chars);
                //MessageBox.Show(szData);

                //when we are sure we received the entire message
                //pass the Object received into parameter 
                //after removing the flag indicating the end of message
                if (szData.Contains(ENDOFMESSAGE))
                {
                    RetrieveReceivedEventData(
                        szData.Remove(szData.IndexOf(ENDOFMESSAGE)),
                        socketData.m_currentSocket.RemoteEndPoint
                        );
                }

                // Continue the waiting for data on the Socket
                WaitForData(socketData.m_currentSocket, socketData.m_clientNumber);

            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054) // Error code for Connection reset by peer
                {
                    //string msg = "Client " + socketData.m_clientNumber + " Disconnected" + "\n";
                    //AppendToRichEditControl(msg);

                    // Remove the reference to the worker socket of the closed client
                    // so that this object will get garbage collected
                    m_workerSocketList[socketData.m_clientNumber - 1] = null;
                    //UpdateClientListControl();
                }
                else
                {
                    Console.WriteLine(se.Message);
                }
            }
        }


        /// <summary>
        /// Retrieve the sent Object.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="endPoint"></param>
        private void RetrieveReceivedEventData(string p, EndPoint endPoint)
        {
            EventData receivedEventData = DeserializeReceivedEventData(p);

            if (ServerSocket_Event != null) 
            {
                ServerSocket_Event(receivedEventData);
            }
            
        }

        /// <summary>
        /// Deserialize an XMLString.
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        private EventData DeserializeReceivedEventData(string xmlString)
        {
            //Deserialize the received Event
            XmlSerializer xmlSerializer;
            MemoryStream memStream = null;
            EventData eventData = new EventData();
            try
            {
                xmlSerializer = new XmlSerializer(typeof(EventData));
                byte[] bytes = new byte[xmlString.Length * 2];
                Encoding.UTF8.GetBytes(xmlString, 0, xmlString.Length, bytes, 0);
                memStream = new MemoryStream(bytes);
                object objectFromXml = xmlSerializer.Deserialize(memStream);
                eventData = (EventData)objectFromXml;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            finally
            {
                if (memStream != null)
                    memStream.Close();
            }
            return eventData;
        }
        String GetIP()
        {
            String strHostName = Dns.GetHostName();

            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

            // Grab the first IP addresses
            String IPStr = "";
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                IPStr = ipaddress.ToString();
                return IPStr;
            }
            return IPStr;
        }

        void CloseSockets()
        {
            if (m_mainSocket != null)
            {
                m_mainSocket.Close();
            }
            Socket workerSocket = null;
            for (int i = 0; i < m_workerSocketList.Count; i++)
            {
                workerSocket = (Socket)m_workerSocketList[i];
                if (workerSocket != null)
                {
                    workerSocket.Close();
                    workerSocket = null;
                }
            }
        }



    }
}
