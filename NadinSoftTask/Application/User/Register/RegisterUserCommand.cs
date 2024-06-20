using Common.Application;
using Common.Domain.ValueObjects;

namespace Application.User.Register;
public class RegisterUserCommand : IBaseCommand
{
    public RegisterUserCommand(string userName, string email, string password)
    {
        UserName = userName;
        Email = email;
        Password = password;
    }

    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}