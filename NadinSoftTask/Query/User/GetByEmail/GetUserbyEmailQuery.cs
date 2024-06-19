using Common.Query;
using Query.User.DTO;

namespace Query.User.GetByEmail;
public record GetUserbyEmailQuery(string Email) : IQuery<UserDTO>;