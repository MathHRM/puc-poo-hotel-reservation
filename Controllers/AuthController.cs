using System;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace Controllers;

public class AuthController : Controller
{
    private UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    // [HttpPost]
    // public Task<ActionResult> LoginModel([FromForm] LoginFormModel user)
    // {

    // }

    [HttpPost]
    public Task<IActionResult> Register([FromForm] LoginFormModel user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        _userService.Add(user);
        return RedirectToAction("Login");
    }


}
