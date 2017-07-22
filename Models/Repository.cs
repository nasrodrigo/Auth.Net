using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

using dotapp.Utils;

namespace dotapp.Models
{
    public class Repository : IRepository
    {
        public const string FILE_NAME = "Data/User.json";

        public void save<T>(T obj)
        {
            DataContractJsonSerializer contract = new DataContractJsonSerializer(typeof(T));

            var obj_json = JsonUtility.ConvertToJson(obj, contract);

            FileUtility.WriteLine(obj_json, FILE_NAME);

            Console.WriteLine("Created: "+obj_json);
        }
        
    }

}
