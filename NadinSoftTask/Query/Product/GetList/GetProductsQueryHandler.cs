using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Product.DTO;

namespace Query.Product.GetList;
public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, List<ProductDTO>>
{
    private readonly Context _context;
    public GetProductsQueryHandler(Context context)
    {
        _context = context;
    }

    public async Task<List<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.ToListAsync();
        if (products == null)
            throw new NullReferenceException(nameof(products));

        return products.Map();
    }
}