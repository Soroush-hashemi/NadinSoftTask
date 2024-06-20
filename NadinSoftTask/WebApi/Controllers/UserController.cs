using Application.User.Services;
using Microsoft.AspNetCore.Mvc;
using PresentationFacade.User;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserFacade _userFacade;
    private readonly IUserService _userService;
    public UserController(IUserFacade userFacade , IUserService userService)
    {
        _userFacade = userFacade;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var users = await _userFacade.GetList();
        
        return Ok(users);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(long Id)
    {
        var user = await _userFacade.GetById(Id);

        return Ok(user);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(string userName , string Email , string Password)
    {
        if (string.IsNullOrEmpty(userName))
            return BadRequest("نام کاربری الزامی است");

        if (string.IsNullOrEmpty(Email))
            return BadRequest("ایمیل الزامی است");

        if (string.IsNullOrEmpty(Password))
            return BadRequest("رمز عبور الزامی است");

        var result = await _userFacade.Register(userName, Email, Password);
        return Ok(result);
    }

    [HttpPost("Login")]
    public IActionResult Login(string Email, string Password)
    {
        if (string.IsNullOrEmpty(Email))
            return BadRequest("ایمیل الزامی است");

        if (string.IsNullOrEmpty(Password))
            return BadRequest("رمز عبور الزامی است");

        var token = _userService.GenerateToken(Email, Password);
        return Ok(token);
    }
}