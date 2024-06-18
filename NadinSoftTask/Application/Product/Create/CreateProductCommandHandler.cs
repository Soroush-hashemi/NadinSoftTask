using Common.Application;
using Common.Domain.Exceptions;
using Domain.Product;

namespace Application.Product.Create;
public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductDomainService _domainService;
    public CreateProductCommandHandler(IProductRepository productRepository , IProductDomainService domainService)
    {
        _productRepository = productRepository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = new Domain.Product.Product(request.UserId, request.Name, request.IsAvailable,
            request.ManufacturerEmail, request.ManufacturerPhone, request.ProduceDate, _domainService);

            _productRepository.Add(product);
            await _productRepository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}