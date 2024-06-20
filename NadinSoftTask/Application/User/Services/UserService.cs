using Domain.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Application.User.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IConfiguration _configuration;
    public UserService(IUserRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    public string GenerateToken(string email, string password)
    {
        var handler = new JwtSecurityTokenHandler();

        ArgumentNullException.ThrowIfNull(email);
        ArgumentNullException.ThrowIfNull(password);

        var user = FindUserByEmail(email);

        var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"]));
        var credential = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

        var claims = GenerateClaims(user);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credential,
            Expires = DateTime.UtcNow.AddHours(1),
            Subject = claims,
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    private Domain.User.User FindUserByEmail(string email)
    {
        var user = _repository.GetUserByEmail(email);
        return user;
    }

    private static ClaimsIdentity GenerateClaims(Domain.User.User user)
    {
        var claims = new ClaimsIdentity();

        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
        claims.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
        return claims;
    }

}