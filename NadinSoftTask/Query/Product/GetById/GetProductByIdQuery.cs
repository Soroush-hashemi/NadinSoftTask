using Common.Query;
using Query.Product.DTO;

namespace Query.Product.GetById;
public record GetProductByIdQuery(long productId) : IQuery<ProductDTO>;