using Common.Query;
using Query.Product.DTOs;
using System;

namespace Query.Product.GetList;
public record GetProductsQuery : IQuery<List<ProductDTO>>;