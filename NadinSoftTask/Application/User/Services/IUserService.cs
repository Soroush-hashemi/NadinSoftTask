namespace Application.User.Services;
public interface IUserService
{
    public string GenerateToken(string email, string password);
}