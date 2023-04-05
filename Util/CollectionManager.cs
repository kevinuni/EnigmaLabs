using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Util
{
    public class CollectionManager
    {
        /// <summary>
        /// Convert IEnumerable collection to Datatable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(IEnumerable list)
        {
            DataTable dt = new DataTable();

            Type elementType = TypeMethods.HeuristicallyDetermineType(list);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                DataColumn dc = new DataColumn();
                dc.ColumnName = propInfo.Name;
                dc.DataType = ColType;
                dc.Caption = TypeMethods.GetDescriptionFromPropertyInfo(propInfo);
                dt.Columns.Add(dc);
            }

            IEnumerator enumerator = list.GetEnumerator();
            if (enumerator.MoveNext())
            {
                //go through each property on T and add each value to the table
                foreach (object item in list)
                {
                    DataRow row = dt.NewRow();

                    foreach (var propInfo in elementType.GetProperties())
                    {
                        row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                    }
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        public static List<T> ToList<T>(DataTable dt) where T : new()
        {
            List<T> list = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                T newObject = new T();
                foreach (DataColumn dc in dt.Columns)
                {
                    PropertyInfo prop = typeof(T).GetProperty(dc.ColumnName);
                    prop.SetValue(newObject, dr[dc]);
                }
                list.Add(newObject);
            }
            return list;
        }
    }
}