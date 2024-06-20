using Application.User.Register;
using Common.Application;
using MediatR;
using Query.User.DTO;
using Query.User.GetByEmail;
using Query.User.GetById;
using Query.User.GetList;

namespace PresentationFacade.User;
public class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;
    public UserFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Register(string userName, string email, string password)
    {
        return await _mediator.Send(new RegisterUserCommand(userName, email, password));
    }

    public async Task<UserDTO> GetByEmail(string email)
    {
        return await _mediator.Send(new GetUserByEmailQuery(email));
    }

    public async Task<UserDTO> GetById(long UserId)
    {
        return await _mediator.Send(new GetUserByIdQuery(UserId));
    }

    public async Task<List<UserDTO>> GetList()
    {
        return await _mediator.Send(new GetUserListQuery());
    }
}