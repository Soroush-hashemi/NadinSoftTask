using Common.Application;
using Domain.Product;

namespace Application.Product.Delete;
public class DeleteProductCommandHandler : IBaseCommandHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;
    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<OperationResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetTracking(request.ProductId);
        if (product is null)
            return OperationResult.Success();

        _productRepository.Delete(product);
        return OperationResult.Success();
    }
}