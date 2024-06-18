using Common.Application;
using Common.Application.SecurityUtil;
using Common.Domain.Exceptions;
using Domain.User;

namespace Application.User.Register;
public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var password = Sha256Hasher.Hash(request.Password);
            var user = new Domain.User.User(request.UserName, request.Email, password);

            _userRepository.Add(user);
            await _userRepository.Save();
            return OperationResult.Success();
        }
        catch (InvalidDomainDataException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}
