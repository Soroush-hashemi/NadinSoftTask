using Application.Product.Create;
using Application.Product.Edit;
using Common.Application;
using Query.Product.DTO;

namespace PresentationFacade.Product;
public interface IProductFacade
{
    Task<OperationResult> Create(CreateProductCommand command);
    Task<OperationResult> Edit(EditProductCommand command);
    Task<OperationResult> Delete(long ProductId);

    Task<List<ProductDTO>> GetPostsList();
    Task<ProductDTO> GetProductById(long ProductId);
    Task<List<ProductDTO>> GetProductsByUserId(long userId);
}