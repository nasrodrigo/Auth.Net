using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace dotapp.Infrastructure.JsonConvert
{
    public sealed class JsonConvert
    {
        public static String ConvertToJson(Object obj, DataContractJsonSerializer contract)
        {
            MemoryStream ms = new MemoryStream();
            contract.WriteObject(ms, obj);
            byte[] json = ms.ToArray();

            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        public static Object ConvertToObject(Object obj, String json)
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer contract = new DataContractJsonSerializer(obj.GetType());  
            
            return contract.ReadObject(ms);
        }
    }
}