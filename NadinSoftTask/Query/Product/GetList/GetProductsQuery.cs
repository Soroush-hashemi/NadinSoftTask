using Common.Query;
using Query.Product.DTO;
using System;

namespace Query.Product.GetList;
public record GetProductsQuery : IQuery<List<ProductDTO>>;