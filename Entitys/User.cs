using System;

using dotapp.Utils;

namespace dotapp.Entitys
{
    public class User : IUser
    {
        public User(){}
        
        public User(String fname, String lname, String email, String login, String password)
        {
            this.fname = fname; 
            this.lname = lname;
            this.email = email;
            this.login = login;
            this.password = HashUtility.HashGenerated(password);
        }
            
        public String fname { get; set; }
        public String lname { get; set; }
        public String email { get; set; }
        public String login { get; set; }
        public String password { get; set; }

        public bool IsUser(String login, String password, User user)
        {
            if(login == user.login && HashUtility.HashValidate(password, user.password))
            {
                return true;
            }

            return false;
        }

    }
}