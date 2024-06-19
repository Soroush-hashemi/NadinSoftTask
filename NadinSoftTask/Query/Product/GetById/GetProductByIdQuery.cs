using Common.Query;
using Query.Product.DTOs;

namespace Query.Product.GetById;
public record GetProductByIdQuery(long productId) : IQuery<ProductDTO>;