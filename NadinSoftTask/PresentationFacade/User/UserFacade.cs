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

    public async Task<OperationResult> Register(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<UserDTO> GetByEmail(GetUserByEmailQuery query)
    {
        return await _mediator.Send(query);
    }

    public async Task<UserDTO> GetById(GetUserByIdQuery query)
    {
        return await _mediator.Send(query);
    }

    public async Task<List<UserDTO>> GetList(GetUserListQuery query)
    {
        return await _mediator.Send(query);
    }
}