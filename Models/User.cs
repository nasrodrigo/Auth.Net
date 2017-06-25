using System;

namespace dotapp.Models
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
                this.password = password; 
            }
            
        public String fname { get; set; }
        public String lname { get; set; }
        public String email { get; set; }
        public String login { get; set; }
        public String password { get; set; }
    }
}