using Application.Product.Create;
using Application.Product.Delete;
using Application.Product.Edit;
using Common.Application;
using MediatR;
using Query.Product.DTO;
using Query.Product.GetById;
using Query.Product.GetByUserId;
using Query.Product.GetList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PresentationFacade.Product;
public class ProductFacade : IProductFacade
{
    private readonly IMediator _mediator;
    public ProductFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(long ProductId)
    {
        return await _mediator.Send(new DeleteProductCommand(ProductId));
    }

    public async Task<OperationResult> Edit(EditProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<List<ProductDTO>> GetPostsList()
    {
        return await _mediator.Send(new GetProductsQuery());
    }

    public async Task<ProductDTO> GetProductById(long ProductId)
    {
        return await _mediator.Send(new GetProductByIdQuery(ProductId));
    }

    public async Task<List<ProductDTO>> GetProductByUserId(long userId)
    {
        return await _mediator.Send(new GetProductsByUserIdQuery(userId));
    }
}