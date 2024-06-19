using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Product.DTO;

namespace Query.Product.GetById;
public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDTO>
{
    private readonly Context _context;
    public GetProductByIdQueryHandler(Context context)
    {
        _context = context;
    }

    public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.productId);
        if (product is null)
            throw new NullReferenceException(nameof(product));

        return product.Map();
    }
}