using Common.Application;

namespace Domain.Product;
public interface IProductDomainService
{
    public OperationResult IsEmailExist(string Email);
    public OperationResult IsProductDateExist(DateTime ProductDate);
}