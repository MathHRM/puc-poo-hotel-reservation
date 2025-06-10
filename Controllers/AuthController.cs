using Microsoft.AspNetCore.Mvc;
using Models;
using Service;
using BCrypt.Net;

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
    public async Task<IActionResult> Register([FromForm] User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        await _userService.CreateAsync(user);
        return RedirectToAction("Login");
    }


}
