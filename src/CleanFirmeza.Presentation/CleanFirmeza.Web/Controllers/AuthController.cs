using CleanFirmeza.Application.DTOs.Auth;
using CleanFirmeza.Application.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanFirmeza.Web.Controllers;

public class AuthController : Controller
{
    private  readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        if (!ModelState.IsValid)
            return View(model);

        
        var result = await _authService.RegisterAsync(model);

        if (result.Success)
            return RedirectToAction("Index", "Home");
        
        foreach (var error in result.Errors ?? new List<string>())
            ModelState.AddModelError(string.Empty, error);
        
        return View(model);
    }
    
     [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var result = await _authService.LoginAsync(
            dto.Email,
            dto.Password,
            dto.RememberMe
        );

        if (!result)
        {
            ModelState.AddModelError(string.Empty, "Correo o contraseña no válidos");
            return View(dto);
        }

        return RedirectToAction("Index", "Home");
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        return RedirectToAction("Login", "Auth");
    }

}

