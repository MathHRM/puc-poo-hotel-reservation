using System;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;


    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }



    