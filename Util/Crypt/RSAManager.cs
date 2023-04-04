using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class RSAManager
    {
        
        private static UnicodeEncoding _encoder = new UnicodeEncoding();

        //private static void Test()
        //{
        //    var rsa = new RSACryptoServiceProvider();
        //    string _privateKey = rsa.ToXmlString(true);
        //    string _publicKey = rsa.ToXmlString(false);

        //    var text = "Test1";
        //    Console.WriteLine("RSA // Text to encrypt: " + text);
        //    var enc = EncryptString(text, _publicKey);
        //    Console.WriteLine("RSA // Encrypted Text: " + enc);
        //    var dec = DecryptString(enc, _privateKey);
        //    Console.WriteLine("RSA // Decrypted Text: " + dec);
        //}

        public static string DecryptString(string data, string _privateKey)
        {
            var rsa = new RSACryptoServiceProvider();
            var dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            rsa.FromXmlString(_privateKey);
            var decryptedByte = rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
        }

        public static string EncryptString(string data, string _publicKey)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(_publicKey);
            var dataToEncrypt = _encoder.GetBytes(data);
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
            var length = encryptedByteArray.Count();
            var item = 0;
            var sb = new StringBuilder();
            foreach (var x in encryptedByteArray)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();
        }


        public static string EncryptObject(byte[] dataToEncrypt, string publicKey)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
            var length = encryptedByteArray.Count();
            var item = 0;
            var sb = new StringBuilder();
            foreach (var x in encryptedByteArray)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();
        }

        public static byte[] DecryptObject(string data, string privateKey)
        {
            var rsa = new RSACryptoServiceProvider();
            var dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            rsa.FromXmlString(privateKey);
            var decryptedByte = rsa.Decrypt(dataByte, false);
            return decryptedByte;
        }
    }
}
