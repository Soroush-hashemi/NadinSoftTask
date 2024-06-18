using Common.Domain.Repository;

namespace Domain.User;
public interface IUserRepository : IBaseRepository<User>
{
    void DeleteUser(User User);
}