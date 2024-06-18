using Common.Application;
using Domain.User;

namespace Application.User.Delete;
public class DeleteUserCommandHandler : IBaseCommandHandler<DeleteUserCommand>
{
    private readonly IUserRepository _repository;
    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _repository = userRepository;
    }

    public async Task<OperationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        _repository.DeleteUser(user);
        await _repository.Save();
        return OperationResult.Success();
    }
}