using Common.Domain.Repository;

namespace Domain.Product;
public interface IProductRepository : IBaseRepository<Product>
{
    void Delete(Product Post);
}