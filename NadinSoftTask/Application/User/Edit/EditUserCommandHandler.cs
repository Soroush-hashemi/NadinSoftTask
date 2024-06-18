using Common.Application;
using Common.Domain.Exceptions;
using Domain.User;
using Microsoft.AspNetCore.Http;

namespace Application.User.Edit;
public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserRepository _userRepository;
    public EditUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            user.Edit(request.UserName, request.Email);

            await _userRepository.Save();
            return OperationResult.Success();
        }
        catch (InvalidDomainDataException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}