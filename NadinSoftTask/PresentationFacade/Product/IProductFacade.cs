using Common.Application;
using Query.Product.DTO;

namespace PresentationFacade.Product;
public interface IProductFacade
{
    Task<OperationResult> Create(long userId, string name, bool isAvailable,
        string manufacturerEmail, string manufacturerPhone, DateTime produceDate);

    Task<OperationResult> Edit(long productId, long userId, string name, bool isAvailable,
        string manufacturerEmail, string manufacturerPhone, DateTime produceDate);

    Task<OperationResult> Delete(long userId, long ProductId);

    Task<List<ProductDTO>> GetPostsList();
    Task<ProductDTO> GetProductById(long ProductId);
    Task<List<ProductDTO>> GetProductsByUserId(long userId);
}