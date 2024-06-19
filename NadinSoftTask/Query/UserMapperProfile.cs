using AutoMapper;
using Query.User.DTO;
namespace Query;
internal class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<Domain.User.User, UserDTO>();
        CreateMap<List<Domain.User.User>, List<UserDTO>>();
    }
}