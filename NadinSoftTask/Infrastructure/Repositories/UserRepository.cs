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

    public User GetUserByEmail(string Email)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == Email);
        if (user is null)
            throw new ArgumentNullException(nameof(user));
        return user;
    }
}