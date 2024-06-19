using AutoMapper;
using Common.Query;
using Domain.Product;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Product.DTO;

namespace Query.Product.GetById;
public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDTO>
{
    private readonly IMapper _mapper;
    private readonly Context _context;
    public GetProductByIdQueryHandler(Context context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.productId);
        if (product is null)
            throw new NullReferenceException(nameof(product));

        var productDTO = _mapper.Map<ProductDTO>(product);
        return productDTO;
    }
}