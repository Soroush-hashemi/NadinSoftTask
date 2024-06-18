using Common.Application;
using Common.Domain.ValueObjects;

namespace Application.Product.Edit;
public record EditProductCommand(long productId,long UserId, string Name, bool IsAvailable,
    string ManufacturerEmail, PhoneNumber ManufacturerPhone, DateTime ProduceDate) : IBaseCommand;