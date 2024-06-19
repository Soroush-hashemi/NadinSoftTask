using Application.User.Register;
using Common.Application;
using Query.User.DTO;
using Query.User.GetByEmail;
using Query.User.GetById;
using Query.User.GetList;

namespace PresentationFacade.User;
public interface IUserFacade
{
    Task<OperationResult> Register(RegisterUserCommand command);
    Task<UserDTO> GetByEmail(GetUserByEmailQuery query);
    Task<UserDTO> GetById(GetUserByIdQuery query);
    Task<List<UserDTO>> GetList(GetUserListQuery query);
}