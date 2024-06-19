using Common.Query;
using Query.User.DTO;

namespace Query.User.GetList;
public record GetUserListQuery : IQuery<List<UserDTO>>;