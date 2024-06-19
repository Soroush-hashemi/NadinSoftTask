using AutoMapper;
using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.User.DTO;

namespace Query.User.GetList;
public class GetUserListQueryHandler : IQueryHandler<GetUserListQuery, List<UserDTO>>
{
    private readonly IMapper _mapper;
    private readonly Context _context;
    public GetUserListQueryHandler(IMapper mapper, Context context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<UserDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users.ToListAsync();
        if (users is null)
            throw new NullReferenceException(nameof(users));

        var userDTO = _mapper.Map<List<UserDTO>>(users);
        return userDTO;
    }
}