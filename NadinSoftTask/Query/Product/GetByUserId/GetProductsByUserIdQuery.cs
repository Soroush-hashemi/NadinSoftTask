using Common.Query;
using Query.Product.DTOs;

namespace Query.Product.GetByUserId;
public record GetProductsByUserIdQuery(long UserId) : IQuery<List<ProductDTO>>;