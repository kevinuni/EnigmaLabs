using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Util
{
    public class TypeConverters
    {
        public static byte[] ToByteArray<T>(T obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
#pragma warning disable SYSLIB0011
                bf.Serialize(ms, obj);
                return ms.ToArray();
#pragma warning restore SYSLIB0011
            }
        }

        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
#pragma warning disable SYSLIB0011
                object obj = bf.Deserialize(ms);
                return (T)obj;
#pragma warning restore SYSLIB0011
            }
        }

        public static T GetValue<T>(string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static T Get<T>(string value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFrom(value);
        }
    }
}