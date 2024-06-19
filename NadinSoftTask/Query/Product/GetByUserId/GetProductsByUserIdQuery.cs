using Common.Query;
using Query.Product.DTO;

namespace Query.Product.GetByUserId;
public record GetProductsByUserIdQuery(long UserId) : IQuery<List<ProductDTO>>;