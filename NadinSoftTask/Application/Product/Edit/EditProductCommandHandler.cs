using Common.Application;
using Common.Domain.Exceptions;
using Domain.Product;

namespace Application.Product.Edit;
public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductDomainService _domainService;
    public EditProductCommandHandler(IProductRepository productRepository, IProductDomainService domainService)
    {
        _productRepository = productRepository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _productRepository.GetTracking(request.productId);
            if (product is null)
                return OperationResult.NotFound();

            if (product.UserId != request.UserId)
                return OperationResult.Error("محصول مربوط به کاربر دیگری است");

            product.Edit(request.Name, request.IsAvailable, request.ManufacturerEmail,
                request.ManufacturerPhone, request.ProduceDate, _domainService);

            await _productRepository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}