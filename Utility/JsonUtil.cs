using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Utility
{
    /// <summary>
    /// JSON类
    /// </summary>
    public class JsonUtil
    {
        public static T Deserialize<T>(string jsonString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static T Deserialize<T>(string jsonString, string dateFormatString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static T DeserializeIgnoreNull<T>(string jsonString)
        {
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            setting.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString , setting );
        }

        public static string Serialize<T>(T obj)
        {
            return Serialize<T>(obj, "yyyy-MM-dd HH:mm:ss");
            //return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
        public static string Serialize<T>(T obj, string dateFormatString)
        {
            Newtonsoft.Json.JsonSerializerSettings set = new Newtonsoft.Json.JsonSerializerSettings();
            set.DateFormatString = dateFormatString;
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, set);
        }
        /// <summary>
        /// 将List转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                dt.Columns.Add(property.Name, property.PropertyType);
            }
            if (data != null)
            {
                object[] values = new object[properties.Count];
                foreach (T item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = properties[i].GetValue(item);
                    }
                    dt.Rows.Add(values);
                }
            }
            return dt;
        }

    }
}
