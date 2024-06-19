using AutoMapper;
using Query.Product.DTO;

namespace Query.Product;
internal class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<Domain.Product.Product, ProductDTO>();
        CreateMap<List<Domain.Product.Product>, List<ProductDTO>>();
    }
}