using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

namespace Util
{
    public class ClientSocket
    {
        byte[] m_dataBuffer = new byte[10];
        IAsyncResult m_result;
        public AsyncCallback m_pfnCallBack;
        public Socket m_clientSocket;
        private const string ENDOFMESSAGE = "ENDOFMESSAGE";

        //----------------------------------------------------	
        // This is a helper function used (for convenience) to 
        // get the IP address of the local machine
        //----------------------------------------------------
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

       
        public String GetIP(string strHostName)
        {
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

        /// <summary>
        /// Intenta hacer conexión al ip remoto
        /// </summary>
        /// <param name="remoteIp"></param>
        /// <returns></returns>
        public bool Connect(string remoteIp, int repotePort )
        {
            // See if we have text on the IP and Port text fields

            try
            {
                // Create the socket instance
                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Cet the remote IP address
                IPAddress ip = IPAddress.Parse(remoteIp);
                
                // Create the end point 
                IPEndPoint ipEnd = new IPEndPoint(ip, repotePort);
                // Connect to the remote host
                m_clientSocket.Connect(ipEnd);
                if (m_clientSocket.Connected)
                {
                    //Wait for data asynchronously 
                    WaitForData();
                }
                return true;
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
                return false;
            }
        }

        public void Disconnect()
        {
            if (m_clientSocket != null)
            {
                m_clientSocket.Close();
                m_clientSocket = null;

            }
        }

        /// <summary>
        /// Envia un mensaje a travez del socket abierto
        /// </summary>
        
        public void SendMessage(string data)
        {
            try
            {
                // New code to send strings
                NetworkStream networkStream = new NetworkStream(m_clientSocket);
                StreamWriter streamWriter = new StreamWriter(networkStream);

                EventData eventData = new EventData(data);

                Object objData = SerializeEventData(eventData) + ENDOFMESSAGE;

                streamWriter.WriteLine(objData);
                streamWriter.Flush();

                /* Use the following code to send bytes
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString ());
                if(m_clientSocket != null){
                    m_clientSocket.Send (byData);
                }
                */
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
            }
        }

        /// <summary>
        /// Serialize a given EventData.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        private string SerializeEventData(EventData eventData)
        {
            StreamWriter stWriter = null;
            XmlSerializer xmlSerializer;
            string buffer;
            try
            {
                xmlSerializer = new XmlSerializer(typeof(EventData));
                MemoryStream memStream = new MemoryStream();
                stWriter = new StreamWriter(memStream);
                System.Xml.Serialization.XmlSerializerNamespaces xs = new XmlSerializerNamespaces();
                xs.Add("", "");
                xmlSerializer.Serialize(stWriter, eventData, xs);
                buffer = Encoding.UTF8.GetString(memStream.GetBuffer());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (stWriter != null)
                    stWriter.Close();
            }
            return buffer;
        }


        public void WaitForData()
        {
            try
            {
                if (m_pfnCallBack == null)
                {
                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.thisSocket = m_clientSocket;
                // Start listening to the data asynchronously
                m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer,
                                                        0, theSocPkt.dataBuffer.Length,
                                                        SocketFlags.None,
                                                        m_pfnCallBack,
                                                        theSocPkt);
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);

            }
        }


        public class SocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[1024];
        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
                int iRx = theSockId.thisSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);

                //do fancy things!!!!

                //SetText(GetText() + szData);
                //richTextRxMessage.Text = richTextRxMessage.Text + szData;
                WaitForData();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
            }
        }
    }
}
