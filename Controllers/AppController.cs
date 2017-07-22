using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;

using dotapp.Entitys;
using dotapp.Models;

namespace dotapp.Controllers
{
    public class AppController : Controller
    {
        private static IRepositoryServiceLocator repositoryServiceLocator;
        private IUserRepository userRepository;
                
        public AppController(IRepositoryServiceLocator _repositoryServiceLocator)
        {
            repositoryServiceLocator = _repositoryServiceLocator;
            userRepository = repositoryServiceLocator.GetRepository<IUserRepository>();
        }

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

            User user = new User(Request.Form["fname"]
                                , Request.Form["lname"]
                                , Request.Form["email"]
                                , Request.Form["login"]
                                , Request.Form["password"]
                                );
            
            userRepository.save<User>(user);

            return RedirectToAction("Login", "App");
        }

        public bool Auth(String login, String password)
        {
            if(userRepository.findByLoginAndPassword(login, password) != null){
                return true;
            }

            return false;
        }

        public IActionResult Welcome()
        {
            return View();
        }
        
    }
}
