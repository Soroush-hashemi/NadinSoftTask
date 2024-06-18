using Common.Application;

namespace Application.Product.Delete;
public record DeleteProductCommand(long ProductId) : IBaseCommand;