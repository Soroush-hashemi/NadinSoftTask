using AutoMapper;
using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Product.DTO;

namespace Query.Product.GetList;
public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, List<ProductDTO>>
{
    private readonly IMapper _mapper;
    private readonly Context _context;
    public GetProductsQueryHandler(Context context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.ToListAsync();
        if (products == null)
            throw new NullReferenceException("وجود ندارد");

        var productDTOs = _mapper.Map<List<ProductDTO>>(products);
        return productDTOs;
    }
}