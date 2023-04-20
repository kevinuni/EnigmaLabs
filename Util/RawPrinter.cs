using System;
using System.Runtime.InteropServices;

namespace Enigma.Util
{
    public class RawPrinter
    {
        public struct DOCINFO
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string DocumentName;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string OutputFile;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string DataType;
        }

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern long OpenPrinter(string pPrinterName, ref IntPtr phPrinter, int pDefault);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern long StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFO pDocInfo);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern long StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern long WritePrinter(IntPtr hPrinter, string data, int buf, ref int pcWritten);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern long EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern long EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern long ClosePrinter(IntPtr hPrinter);

        public static void SendToPrinter(string printerJobName, string rawStringToSendToThePrinter, string printerNameAsDescribedByPrintManager)
        {
            IntPtr handleForTheOpenPrinter = new IntPtr();
            DOCINFO documentInformation = new DOCINFO();
            int printerBytesWritten = 0;
            documentInformation.DocumentName = printerJobName;
            documentInformation.DataType = Microsoft.VisualBasic.Constants.vbNullString;
            documentInformation.OutputFile = Microsoft.VisualBasic.Constants.vbNullString;
            OpenPrinter(printerNameAsDescribedByPrintManager, ref handleForTheOpenPrinter, 0);
            StartDocPrinter(handleForTheOpenPrinter, 1, ref documentInformation);
            StartPagePrinter(handleForTheOpenPrinter);
            WritePrinter(handleForTheOpenPrinter, rawStringToSendToThePrinter, rawStringToSendToThePrinter.Length, ref printerBytesWritten);
            EndPagePrinter(handleForTheOpenPrinter);
            EndDocPrinter(handleForTheOpenPrinter);
            ClosePrinter(handleForTheOpenPrinter);
        }
    }
}