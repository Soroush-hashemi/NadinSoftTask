using Common.Application;
using Domain.Product;

namespace Application.Product;
public class ProductDomainService : IProductDomainService
{
    private readonly IProductRepository _repository;
    public ProductDomainService(IProductRepository repository)
    {
        _repository = repository;
    }

    public OperationResult IsEmailExist(string Email)
    {
        var Exists = _repository.Exists(s => s.ManufacturerEmail == Email);
        if (Exists == false)
            return OperationResult.Success();

        return OperationResult.Error("Email تکراری است");
    }

    public OperationResult IsProductDateExist(DateTime ProductDate)
    {
        var Exists = _repository.Exists(s => s.ProduceDate == ProductDate);
        if (Exists == false)
            return OperationResult.Success();

        return OperationResult.Error("ProductDate تکراری است");
    }
}