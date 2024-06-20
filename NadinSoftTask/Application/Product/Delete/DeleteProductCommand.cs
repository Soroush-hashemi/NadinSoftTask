using Common.Application;

namespace Application.Product.Delete;
public record DeleteProductCommand(long userId, long ProductId) : IBaseCommand;