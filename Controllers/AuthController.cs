using Microsoft.AspNetCore.Mvc;
using Models;
using Service;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Controllers;

public class AuthController : Controller
{
    private readonly UserService _userService;
    private readonly AuthService _authService;

    public AuthController(UserService userService, AuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    public IActionResult Register()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    public IActionResult Login()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginModel([FromForm] LoginFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Login", model);
        }

        var success = await _authService.LoginAsync(model);

        if (!success)
        {
            ModelState.AddModelError(string.Empty, "Email ou senha inválidos");
            return View("Login", model);
        }

        return RedirectToAction("Index", "Home");
    }

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

    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }
}
