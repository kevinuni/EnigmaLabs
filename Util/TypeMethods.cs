using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Enigma.Util
{
    public class TypeMethods
    {
        public static string GetDescriptionFromMemberInfo(MemberInfo mi)
        {
            var descriptions = (DescriptionAttribute[])mi.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (descriptions.Length == 0)
            {
                return null;
            }
            return descriptions[0].Description;
        }

        public static string GetDescriptionFromFieldInfo(FieldInfo fi)
        {
            var descriptions = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (descriptions.Length == 0)
            {
                return null;
            }
            return descriptions[0].Description;
        }

        /// <summary>
        /// returns the description attribute from a class property
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static string GetDescriptionFromPropertyInfo(PropertyInfo pi)
        {
            var descriptions = (DescriptionAttribute[])pi.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (descriptions.Length == 0)
            {
                return null;
            }
            return descriptions[0].Description;
        }

        public static string GetDescriptionFromType(Type type)
        {
            var descriptions = (DescriptionAttribute[])type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptions.Length == 0)
            {
                return null;
            }
            return descriptions[0].Description;
        }

        /// <summary>
        /// Determine Type of object who belongs to a IEnumerable collection
        /// </summary>
        /// <param name="collection">Collection of object to look for him type</param>
        /// <returns></returns>
        public static Type HeuristicallyDetermineType(IEnumerable collection)
        {
            var enumerable_type =
                collection.GetType()
                .GetInterfaces()
                .Where(i => i.IsGenericType && i.GenericTypeArguments.Length == 1)
                .FirstOrDefault(i => i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            if (enumerable_type != null)
                return enumerable_type.GenericTypeArguments[0];

            IEnumerator enumerator = collection.GetEnumerator();
            if (enumerator.MoveNext() == false)
                return null;

            return enumerator.Current.GetType();
        }
    }
}