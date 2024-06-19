using Query.Product.DTO;
using Query.User.DTO;

namespace Query.User;
internal static class UserMapper
{
    public static UserDTO Map(this Domain.User.User user)
    {
        return new UserDTO()
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Password = user.Password,
        };
    }

    public static List<UserDTO> Map(this List<Domain.User.User> Users)
    {
        return Users.Select(user => user.Map()).ToList();
    }
}