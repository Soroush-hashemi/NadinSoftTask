using Application.User.Register;
using Microsoft.AspNetCore.Mvc;
using PresentationFacade.User;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserFacade _userFacade;
    public UserController(IUserFacade userFacade)
    {
        _userFacade = userFacade;
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
        if (userName is null)
            throw new NullReferenceException();

        if (Email is null)
            throw new NullReferenceException();

        if (Password is null)
            throw new NullReferenceException();

        var result = await _userFacade.Register(userName, Email, Password);
        return Ok(result);
    }
}