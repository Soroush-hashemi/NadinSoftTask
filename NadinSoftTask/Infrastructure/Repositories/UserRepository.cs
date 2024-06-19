using Domain.Product;
using Domain.User;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;
internal class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context)
    {

    }

    public void DeleteUser(User User)
    {
        if (User is null)
            throw new ArgumentNullException(nameof(User));

        _context.Users.Remove(User);
    }
}