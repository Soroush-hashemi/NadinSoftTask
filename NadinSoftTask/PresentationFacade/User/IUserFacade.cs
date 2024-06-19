using Application.User.Register;
using Common.Application;
using Query.User.DTO;
using Query.User.GetByEmail;

namespace PresentationFacade.User;
public interface IUserFacade
{
    Task<OperationResult> Register(RegisterUserCommand command);
    Task<UserDTO> GetByEmail(GetUserByEmailQuery query);
}