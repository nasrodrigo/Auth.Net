using System;
using System.Runtime.Serialization.Json;

using Auth.Net.Infrastructure.JsonConvert;
using Auth.Net.Infrastructure.HandlerFile;

namespace Auth.Net.Domain.Model.Repositorys
{
    public class Repository : IRepository
    {
        public const string FILE_NAME = "DB/User.json";

        public void save<T>(T obj)
        {
            DataContractJsonSerializer contract = new DataContractJsonSerializer(typeof(T));

            var obj_json = JsonConvert.ConvertToJson(obj, contract);

            HandlerFile.WriteLine(obj_json, FILE_NAME);

            Console.WriteLine("Created: "+obj_json);
        }
        
    }

}
