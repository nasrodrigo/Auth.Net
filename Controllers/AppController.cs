using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;

using dotapp.Util;
using dotapp.Models;

namespace dotapp.Controllers
{
    public class AppController : Controller
    {
        private const string FILE_NAME = "Data/User.json";
        private JsonUtility jsonUtility = new JsonUtility();
        private Authentic auth = new Authentic();

        public IActionResult Index()
        {
            return RedirectToAction("Login", "App");
        }

        public IActionResult Login( String login, String password, String add )
        {   
            ViewData["title"] = "Login";
            ViewData["login"] = login;
            ViewData["password"] = password;
            ViewData["add"] = add;

            if(password != null){
                if(Auth(login, password))
                {
                    return RedirectToAction("Welcome", "App");
                }
            }

            return View();
        }

        public IActionResult AddUser()
        {
            if(Request.Form["password"]!=Request.Form["cpassword"])
            {
                return RedirectToAction("Login", "App");
            }

            var pass = auth.HashGenerated(Request.Form["password"]);
            
            User user = new User(Request.Form["fname"]
                                , Request.Form["lname"]
                                , Request.Form["email"]
                                , Request.Form["login"]
                                , pass
                                 );
            
            DataContractJsonSerializer dt = new DataContractJsonSerializer(typeof(User));

            var user_json = jsonUtility.ConvertToJson(user, dt);

            using (StreamWriter w = System.IO.File.AppendText(FILE_NAME))
            {
                Console.WriteLine("User created: "+user_json);
                w.WriteLine(user_json);
            }

            return RedirectToAction("Login", "App");
        }

        public bool Auth(String login, String password)
        {
            using (FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader r = new StreamReader(fs))
                {
                    String line;
                    while ((line = r.ReadLine()) != null)
                    {
                        User user = new User();
                        user = jsonUtility.ConvertToObject(user, line) as User;
                        if(login == user.login && auth.HashValidate(password, user.password))
                        {
                            Console.WriteLine("Ok!");
                            return true;
                        }
                    }
                    
                }
            }

            return false;
        }

        public IActionResult Welcome()
        {
            return View();
        }
        
    }
}
