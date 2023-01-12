using alidddd.Application.Auth;
using alidddd.Contracts.Auth;
using Microsoft.AspNetCore.Mvc;

namespace alidddd.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController:ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("register")]
    public IActionResult Register(RegisterRequest request)
    {
        
        return Ok(_authService.Register(request.Name,request.Pwd,request.Email));
    }
    
    [HttpPost]
    [Route("login")]
    public IActionResult Login(LoginRequest request)
    {
        var _login = _authService.Login(request.Email, request.Pwd);
        var response = new AuthResponse(_login.Id, _login.Name, _login.Role, _login.Token);
        return Ok(response);
    }
}