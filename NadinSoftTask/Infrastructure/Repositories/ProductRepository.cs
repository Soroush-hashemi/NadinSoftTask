using Domain.Product;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;
internal class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(Context context) : base(context)
    {
    }

    public void Delete(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));

        _context.Products.Remove(product);
    }
}