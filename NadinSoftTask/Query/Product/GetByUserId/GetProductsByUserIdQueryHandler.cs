using AutoMapper;
using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Product.DTO;

namespace Query.Product.GetByUserId;
public class GetProductsByUserIdQueryHandler : IQueryHandler<GetProductsByUserIdQuery, List<ProductDTO>>
{
    private readonly IMapper _mapper;
    private readonly Context _context;
    public GetProductsByUserIdQueryHandler(Context context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductDTO>> Handle(GetProductsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.Where(x => x.UserId == request.UserId).ToListAsync();
        if (products is null)
            throw new NullReferenceException();

        var productDTOs = _mapper.Map<List<ProductDTO>>(products);
        return productDTOs;
    }
}