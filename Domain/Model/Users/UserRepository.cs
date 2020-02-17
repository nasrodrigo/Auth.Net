using System;
using System.Collections.Generic;

using dotapp.Infrastructure.HandlerFile;
using dotapp.Infrastructure.JsonConvert;
using dotapp.Domain.Model.Repositorys;

namespace dotapp.Domain.Model.Users
{
    public class UserRepository : Repository, IUserRepository
    {
        public User findByLoginAndPassword(String login, String password)
        {
            User user = new User();
            foreach(String line in HandlerFile.RaedLine(FILE_NAME))
            {
                user = JsonConvert.ConvertToObject(user, line) as User;
                
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
