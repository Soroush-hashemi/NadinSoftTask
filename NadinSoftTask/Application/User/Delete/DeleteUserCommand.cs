using Common.Application;

namespace Application.User.Delete;
public record DeleteUserCommand(long UserId) : IBaseCommand;