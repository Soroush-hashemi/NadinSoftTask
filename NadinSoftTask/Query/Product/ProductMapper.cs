using Query.Product.DTO;

namespace Query.Product;
internal static class ProductMapper
{
    public static ProductDTO Map(this Domain.Product.Product product)
    {
        return new ProductDTO()
        {
            ProductId = product.Id,
            UserId = product.UserId,
            Name = product.Name,
            IsAvailable = product.IsAvailable,
            ManufacturerEmail = product.ManufacturerEmail,
            ManufacturerPhone = product.ManufacturerPhone.Value,
            ProduceDate = product.ProduceDate,
        };
    }

    public static List<ProductDTO> Map(this List<Domain.Product.Product> products)
    {
        return products.Select(product => product.Map()).ToList();
    }
}