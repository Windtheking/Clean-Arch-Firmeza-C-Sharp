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
    
    [HttpGet]
    public IActionResult Login()
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

        return View(model);
    }
}
