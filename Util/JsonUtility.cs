using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace dotapp.Util
{
    public class JsonUtility
    {
        public String ConvertToJson(Object obj, DataContractJsonSerializer dt)
        {
            MemoryStream ms = new MemoryStream();
            dt.WriteObject(ms, obj);
            byte[] json = ms.ToArray();

            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        public Object ConvertToObject(Object obj, String json)
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer dt = new DataContractJsonSerializer(obj.GetType());  
            
            return dt.ReadObject(ms);
        }
    }
}