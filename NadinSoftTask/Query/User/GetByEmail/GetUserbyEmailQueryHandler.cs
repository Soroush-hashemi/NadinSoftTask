using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.User.DTO;

namespace Query.User.GetByEmail;
public class GetUserbyEmailQueryHandler : IQueryHandler<GetUserbyEmailQuery, UserDTO>
{
    private readonly Context _context;
    public GetUserbyEmailQueryHandler(Context context)
    {
        _context = context;
    }

    public async Task<UserDTO> Handle(GetUserbyEmailQuery request, CancellationToken cancellationToken)
    {
        var User = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (User is null)
             throw new NullReferenceException(nameof(User));

        return User.Map();
    }
}