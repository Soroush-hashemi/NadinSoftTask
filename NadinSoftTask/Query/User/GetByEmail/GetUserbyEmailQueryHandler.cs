using AutoMapper;
using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.User.DTO;

namespace Query.User.GetByEmail;
public class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserDTO>
{
    private readonly IMapper _mapper;
    private readonly Context _context;
    public GetUserByEmailQueryHandler(Context context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<UserDTO> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var User = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (User is null)
            throw new NullReferenceException(nameof(User));

        var userDTO = _mapper.Map<UserDTO>(User);
        return userDTO;
    }
}