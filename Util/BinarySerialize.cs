using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class BinarySerialize
    {
        public static T DeepClone<T>(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the XML file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the XML.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// serializes the given object into memory stream
        /// </summary>
        /// <param name="objectType">the object to be serialized</param>
        /// <returns>The serialized object as memory stream</returns>
        public static MemoryStream SerializeToStream(object objectType)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, objectType);
            return stream;

        }

        /// <summary>
        /// deserializes as an object
        /// </summary>
        /// <param name="stream">the stream to deserialize</param>
        /// <returns>the deserialized object</returns>
        public static object DeserializeFromStream(MemoryStream stream)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
                stream.Seek(0, SeekOrigin.Begin);
                object objectType = formatter.UnsafeDeserialize(stream, null);

                return objectType;


                //BinaryFormatter formatter = new BinaryFormatter();
                ////This is the most important part
                //formatter.Binder = new BinaryConvertor();
                //object temp = formatter.Deserialize(stream);
                //stream.Close();

                //return temp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;

        }

        public static string FriendlyGetString(byte[] bytes)
        {
            var item = 0;
            var sb = new StringBuilder();
            var length = bytes.Count();
            foreach (var x in bytes)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();

        }

        public static byte[] FriendlyGetBytes(string data)
        {
            var dataArray = data.Split(new char[] { ',' });
            byte[] bytes = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                bytes[i] = Convert.ToByte(dataArray[i]);
            }
            return bytes;
        }
    }
}
