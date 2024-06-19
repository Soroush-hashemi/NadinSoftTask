using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Product.DTOs;

namespace Query.Product.GetByUserId;
public class GetProductsByUserIdQueryHandler : IQueryHandler<GetProductsByUserIdQuery, List<ProductDTO>>
{
    private readonly Context _context;
    public GetProductsByUserIdQueryHandler(Context context)
    {
        _context = context;
    }

    public async Task<List<ProductDTO>> Handle(GetProductsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.Where(x => x.UserId == request.UserId).ToListAsync();
        if (products is null)
            throw new NullReferenceException();

        return products.Map();
    }
}