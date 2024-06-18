using Common.Domain.Bases;
using Common.Domain.Exceptions;
using Common.Domain.Tools;
using Common.Domain.ValueObjects;

namespace Domain.User;
public class User : BaseEntity
{
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    private User()
    {

    }

    public User(string userName, string email, string password)
    {
        Guard(email);
        UserName = userName;
        Email = email;
        Password = password;
    }

    public void Edit(string userName, string email)
    {
        Guard(email);
        UserName = userName;
        Email = email;
    }

    public void Guard(string email)
    {
        if (!string.IsNullOrWhiteSpace(email))
            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException("ایمیل نامعتبر است");
    }
}