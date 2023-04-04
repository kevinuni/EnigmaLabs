using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections;
using System.IO;

namespace Util
{
    public class ZipManager
    {
        public static byte[] ZipToStream(byte[] input)
        {
            MemoryStream outputStream = new MemoryStream();
            ZipOutputStream zipOutputStram = new ZipOutputStream(outputStream);

            zipOutputStram.SetLevel(3); //0-9, 9 being the highest level of compression

            //zipOutputStram.Password = "gl3xc0";  // optional. Null is the same as not setting. Required if using AES.

            // This setting will strip the leading part of the folder path in the entries, to
            // make the entries relative to the starting folder.
            // To include the full path for each entry up to the drive root, assign folderOffset = 0.

            ZipEntry entry = new ZipEntry("modelo.xlsm");
            entry.DateTime = DateTime.Now;
            entry.Size = input.Length;

            zipOutputStram.PutNextEntry(entry);
            byte[] buffer = new byte[4096];

            Stream stream = new MemoryStream(input);
            StreamUtils.Copy(stream, zipOutputStram, buffer);

            zipOutputStram.CloseEntry();
            zipOutputStram.IsStreamOwner = true;

            zipOutputStram.Finish();
            zipOutputStram.Close();

            byte[] byteArrayOut = outputStream.ToArray();

            outputStream.Close();

            return byteArrayOut;
        }

        /// <summary>
        /// Comprime un arreglo de vytes
        /// </summary>
        /// <param name="inputBytes">Bytes a ser comprimidos</param>
        /// <param name="filename">Nombre del archivo bajo el que se pondrá la data</param>
        /// <returns></returns>
        public static byte[] ZipToByteArray(byte[] inputBytes, string filename, string password = "")
        {
            MemoryStream outputStream = new MemoryStream();
            ZipOutputStream zipOutputStram = new ZipOutputStream(outputStream);

            zipOutputStram.SetLevel(3); //0-9, 9 being the highest level of compression

            if (!string.IsNullOrWhiteSpace(password))
            {
                zipOutputStram.Password = password;  // optional. Null is the same as not setting. Required if using AES.
            }

            // This setting will strip the leading part of the folder path in the entries, to
            // make the entries relative to the starting folder.
            // To include the full path for each entry up to the drive root, assign folderOffset = 0.

            ZipEntry entry = new ZipEntry(filename);
            entry.DateTime = DateTime.Now;
            entry.Size = inputBytes.Length;

            zipOutputStram.PutNextEntry(entry);
            byte[] buffer = new byte[4096];

            Stream stream = new MemoryStream(inputBytes);
            StreamUtils.Copy(stream, zipOutputStram, buffer);

            zipOutputStram.CloseEntry();
            zipOutputStram.IsStreamOwner = true;

            zipOutputStram.Finish();
            zipOutputStram.Close();

            byte[] byteArrayOut = outputStream.ToArray();

            outputStream.Close();

            return byteArrayOut;
        }

        /// <summary>
        /// Comprimir un conjunto de arreglos de bytes
        /// </summary>
        /// <param name="hsFiles">Conjunto de arreglos de bytes a comprimir
        /// key: nombre de los archivos
        /// value: data de los archivos</param>
        /// <param name="password">Contraseña del archivo zip</param>
        /// <returns></returns>
        public static byte[] ZipToByteArray(Hashtable hsFiles, string password = "")
        {
            MemoryStream outputStream = new MemoryStream();
            ZipOutputStream zipOutputStream = new ZipOutputStream(outputStream);

            // fix compression level [0-9]
            zipOutputStream.SetLevel(0);

            if (!string.IsNullOrWhiteSpace(password))
            {
                zipOutputStream.Password = password;
            }

            foreach (string key in hsFiles.Keys)
            {
                string filename = key;
                ZipEntry entry = new ZipEntry(filename);
                entry.DateTime = DateTime.Now;

                if (hsFiles[key] is byte[])
                {
                    byte[] inputBytes = (byte[])hsFiles[key];
                    entry.Size = inputBytes.Length;

                    zipOutputStream.PutNextEntry(entry);
                    byte[] buffer = new byte[4096];

                    Stream stream = new MemoryStream(inputBytes);

                    StreamUtils.Copy(stream, zipOutputStream, buffer);
                }
                else if (hsFiles[key] is string)
                {
                    string path = (string)hsFiles[key];

                    FileInfo fi = new FileInfo(path);
                    entry.Size = fi.Length;

                    zipOutputStream.PutNextEntry(entry);
                    byte[] buffer = new byte[4096];
                    FileStream streamReader = File.OpenRead(path);
                    StreamUtils.Copy(streamReader, zipOutputStream, buffer);
                }
                else
                {
                    throw new Exception("bad type");
                }

                zipOutputStream.CloseEntry();
                zipOutputStream.IsStreamOwner = true;
            }

            zipOutputStream.Finish();
            zipOutputStream.Close();

            byte[] byteArrayOut = outputStream.ToArray();

            outputStream.Close();

            return byteArrayOut;
        }

        /// <summary>
        /// Comprime una carpeta a un arreglo de bytes
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public static byte[] ZipFolderToByteArray(string folderName, string password = "")
        {
            MemoryStream outputStream = new MemoryStream();
            ZipOutputStream zipOutputStream = new ZipOutputStream(outputStream);

            zipOutputStream.SetLevel(3); //0-9, 9 being the highest level of compression

            if (!string.IsNullOrWhiteSpace(password))
            {
                zipOutputStream.Password = password;  // optional. Null is the same as not setting. Required if using AES.
            }

            // This setting will strip the leading part of the folder path in the entries, to
            // make the entries relative to the starting folder.
            // To include the full path for each entry up to the drive root, assign folderOffset = 0.
            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);

            CompressFolder(folderName, zipOutputStream, folderOffset);

            zipOutputStream.IsStreamOwner = true; // Makes the Close also Close the underlying stream

            zipOutputStream.Finish();
            zipOutputStream.Close();

            byte[] byteArrayOut = outputStream.ToArray();
            outputStream.Close();

            return byteArrayOut;
        }

        /// <summary>
        /// Comprimir una carpeta a un zip
        /// </summary>
        /// <param name="path"></param>
        /// <param name="zipStream"></param>
        /// <param name="folderOffset"></param>
        private static void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {
            string[] files = Directory.GetFiles(path);

            foreach (string filename in files)
            {
                FileInfo fi = new FileInfo(filename);

                string entryName = filename.Substring(folderOffset); // Makes the name in zip based on the folder
                entryName = ZipEntry.CleanName(entryName); // Removes drive from name and fixes slash direction
                ZipEntry zipEntry = new ZipEntry(entryName);

                #region [Crear el zipentry]

                zipEntry.DateTime = fi.LastWriteTime; // Note the zip format stores 2 second granularity

                // Specifying the AESKeySize triggers AES encryption. Allowable values are 0 (off), 128 or 256.
                // A password on the ZipOutputStream is required if using AES.
                //   newEntry.AESKeySize = 256;

                // To permit the zip to be unpacked by built-in extractor in WinXP and Server2003, WinZip 8, Java, and other older code,
                // you need to do one of the following: Specify UseZip64.Off, or set the Size.
                // If the file may be bigger than 4GB, or you do not need WinXP built-in compatibility, you do not need either,
                // but the zip will be in Zip64 format which not all utilities can understand.
                //   zipStream.UseZip64 = UseZip64.Off;
                zipEntry.Size = fi.Length;

                zipStream.PutNextEntry(zipEntry);

                #endregion [Crear el zipentry]

                #region [Copiar la data al zipstream]

                byte[] buffer = new byte[4096];
                using (FileStream streamReader = File.OpenRead(filename))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }

                #endregion [Copiar la data al zipstream]

                zipStream.CloseEntry();
            }
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFolder(folder, zipStream, folderOffset);
            }
        }

        /// <summary>
        /// Descomprimir un arreglo de bytes a una carpeta dada
        /// </summary>
        /// <param name="zipInputBytes">arreglo de bytes del archivo comprimido</param>
        /// <param name="outputFolder">carpeta a donde se va a descomprimir</param>
        public static void UnzipFromByteArray(byte[] zipInputBytes, string outputFolder)
        {
            MemoryStream stream = new MemoryStream(zipInputBytes);
            ZipInputStream zipInputStream = new ZipInputStream(stream);
            ZipEntry zipEntry = zipInputStream.GetNextEntry();

            while (zipEntry != null)
            {
                String entryFileName = zipEntry.Name;
                // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                // Optionally match entrynames against a selection list here to skip as desired.
                // The unpacked length is available in the zipEntry.Size property.

                byte[] buffer = new byte[4096];     // 4K is optimum

                // Manipulate the output filename here as desired.
                String fullZipToPath = Path.Combine(outputFolder, entryFileName);
                //Crear el directorio de destino
                string directoryName = Path.GetDirectoryName(fullZipToPath);
                if (directoryName.Length > 0)
                {
                    Directory.CreateDirectory(directoryName);
                }

                // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                // of the file, but does not waste memory.
                // The "using" will close the stream even if an exception occurs.
                using (FileStream streamWriter = File.Create(fullZipToPath))
                {
                    StreamUtils.Copy(zipInputStream, streamWriter, buffer);
                }
                zipEntry = zipInputStream.GetNextEntry();
            }
        }
    }
}