using System;
using Microsoft.AspNetCore.Mvc;

using Auth.Net.Domain.Model.Users;
using Auth.Net.Interfaces.Users.Facade;

namespace Auth.Net.Interfaces.Users.Web
{
    public class UserController : Controller
    {
        IUserFacadeService facedeService;
        public UserController()
        {
            this.facedeService = new UserFacadeService();
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "User");
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
                    return RedirectToAction("Welcome", "User");
                }
            }

            return View();
        }

        public IActionResult AddUser()
        {
            if(Request.Form["password"]!=Request.Form["cpassword"])
            {
                return RedirectToAction("Login", "User");
            }

            User user = new User(Request.Form["fname"]
                                , Request.Form["lname"]
                                , Request.Form["email"]
                                , Request.Form["login"]
                                , Request.Form["password"]
                                );
            
            facedeService.save(user);

            return RedirectToAction("Login", "User");
        }

        public bool Auth(String login, String password)
        {
            if(facedeService.findByLoginAndPassword(login, password) != null){
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
