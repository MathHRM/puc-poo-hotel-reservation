using System;
using Microsoft.AspNetCore.Mvc;
using Models;

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

    //[HttpPost]
    //public Task<ActionResult> LoginModel([FromForm] LoginFormModel user)
    //{
        
    //}
}
