using Application.Product.Create;
using Application.Product.Delete;
using Application.Product.Edit;
using Common.Application;
using Common.Domain.ValueObjects;
using MediatR;
using Query.Product.DTO;
using Query.Product.GetById;
using Query.Product.GetByUserId;
using Query.Product.GetList;

namespace PresentationFacade.Product;
public class ProductFacade : IProductFacade
{
    private readonly IMediator _mediator;
    public ProductFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(long userId, string name, bool isAvailable,
        string manufacturerEmail, string manufacturerPhone, DateTime produceDate)
    {
        return await _mediator.Send(new CreateProductCommand(userId, name, isAvailable,
            manufacturerEmail, new PhoneNumber(manufacturerPhone), produceDate));
    }

    public async Task<OperationResult> Delete(long UserId, long ProductId)
    {
        return await _mediator.Send(new DeleteProductCommand(UserId, ProductId));
    }

    public async Task<OperationResult> Edit(long productId, long userId, string name, bool isAvailable,
        string manufacturerEmail, string manufacturerPhone, DateTime produceDate)
    {
        return await _mediator.Send(new EditProductCommand(productId, userId, name, isAvailable,
            manufacturerEmail, new PhoneNumber(manufacturerPhone), produceDate));
    }

    public async Task<List<ProductDTO>> GetPostsList()
    {
        return await _mediator.Send(new GetProductsQuery());
    }

    public async Task<ProductDTO> GetProductById(long ProductId)
    {
        return await _mediator.Send(new GetProductByIdQuery(ProductId));
    }

    public async Task<List<ProductDTO>> GetProductsByUserId(long userId)
    {
        return await _mediator.Send(new GetProductsByUserIdQuery(userId));
    }
}