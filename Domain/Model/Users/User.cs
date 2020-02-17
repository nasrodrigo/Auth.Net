using System;

using Auth.Net.Infrastructure.BCrypt.Net;

namespace Auth.Net.Domain.Model.Users
{
    public class User
    {
        public User(){}
        
        public User(String fname, String lname, String email, String login, String password)
        {
            this.fname = fname; 
            this.lname = lname;
            this.email = email;
            this.login = login;
            this.password = HandlerBCrypt.HashGenerated(password);
        }
            
        public String fname { get; set; }
        public String lname { get; set; }
        public String email { get; set; }
        public String login { get; set; }
        public String password { get; set; }

        public bool IsUser(String login, String password, User user)
        {
            if(login == user.login && HandlerBCrypt.HashValidate(password, user.password))
            {
                return true;
            }

            return false;
        }

    }
}