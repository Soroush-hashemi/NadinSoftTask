using AutoMapper;
using Query.User.DTO;

namespace Query.User;
public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<Domain.User.User, UserDTO>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
    }
}