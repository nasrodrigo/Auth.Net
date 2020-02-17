using System;
using System.Collections.Generic;

using Auth.Net.Infrastructure.HandlerFile;
using Auth.Net.Infrastructure.JsonConvert;
using Auth.Net.Domain.Model.Repositorys;

namespace Auth.Net.Domain.Model.Users
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
