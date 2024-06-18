using Common.Application;
using Common.Domain.ValueObjects;

namespace Application.Product.Create;
public record CreateProductCommand(long UserId, string Name, bool IsAvailable,
    string ManufacturerEmail, PhoneNumber ManufacturerPhone, DateTime ProduceDate) : IBaseCommand;