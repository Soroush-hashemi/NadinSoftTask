using Common.Query;
using Query.User.DTO;

namespace Query.User.GetById;
public record GetUserByIdQuery(long UserId) : IQuery<UserDTO>;