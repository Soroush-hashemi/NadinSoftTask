using Common.Application;
using Query.User.DTO;
using Query.User.GetList;

namespace PresentationFacade.User;
public interface IUserFacade
{
    Task<OperationResult> Register(string userName, string email, string password);
    Task<UserDTO> GetByEmail(string email);
    Task<UserDTO> GetById(long UserId);
    Task<List<UserDTO>> GetList();
}