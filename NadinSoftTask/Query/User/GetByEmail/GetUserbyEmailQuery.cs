using Common.Query;
using Query.User.DTO;

namespace Query.User.GetByEmail;
public record GetUserByEmailQuery(string Email) : IQuery<UserDTO>;