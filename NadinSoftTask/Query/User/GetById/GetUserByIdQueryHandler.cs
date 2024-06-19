using AutoMapper;
using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.User.DTO;

namespace Query.User.GetById;
public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDTO>
{
    private readonly IMapper _mapper;
    private readonly Context _context;
    public GetUserByIdQueryHandler(IMapper mapper, Context context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
        if (user is null)
            throw new NullReferenceException();

        var userDTO = _mapper.Map<UserDTO>(user);
        return userDTO;
    }
}