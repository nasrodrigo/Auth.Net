using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

using dotapp.Utils;
using dotapp.Entitys;

namespace dotapp.Models
{
    public class UserRepository : Repository, IUserRepository
    {
        public User findByLoginAndPassword(String login, String password)
        {
            User user = new User();
            foreach(String line in FileUtility.RaedLine(FILE_NAME))
            {
                user = JsonUtility.ConvertToObject(user, line) as User;
                
                if(user.IsUser(login, password, user))
                {
                    Console.WriteLine("Find user: "+user.login+" - "+user.email);
                    return user;
                }

            }
            Console.WriteLine("User not found");
            return null;
        }
    }
}
