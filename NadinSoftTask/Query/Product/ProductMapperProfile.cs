using AutoMapper;
using Query.Product.DTO;

namespace Query.Product;
public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<Domain.Product.Product, ProductDTO>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ManufacturerPhone, opt => opt.MapFrom(src => src.ManufacturerPhone.Value));
    }
}