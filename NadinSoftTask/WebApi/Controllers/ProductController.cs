using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationFacade.Product;
using Query.User.DTO;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductFacade _productFacade;
    public ProductController(IProductFacade productFacade)
    {
        _productFacade = productFacade;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var products = await _productFacade.GetPostsList();

        return Ok(products);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(long Id)
    {
        var user = await _productFacade.GetProductById(Id);

        return Ok(user);
    }

    [HttpGet("GetByUserId {UserId}")]
    public async Task<IActionResult> GetByUserId(long UserId)
    {
        var user = await _productFacade.GetProductsByUserId(UserId);

        return Ok(user);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post(long userId, string name, bool isAvailable,
        string manufacturerEmail, string manufacturerPhone, DateTime produceDate)
    {
        var result = await _productFacade.Create(userId, name, isAvailable,
            manufacturerEmail, manufacturerPhone, produceDate);

        return Ok(result);
    }

    [Authorize]
    [HttpPut("Edit")]
    public async Task<IActionResult> Edit(long userId, long productId, string name, bool isAvailable,
        string manufacturerEmail, string manufacturerPhone, DateTime produceDate)
    {
        var result = await _productFacade.Edit(productId, userId, name, isAvailable,
            manufacturerEmail, manufacturerPhone, produceDate);

        return Ok(result);
    }

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> Delete(long userId, long productId)
    {
        var result = await _productFacade.Delete(userId, productId);
        return Ok(result);
    }
}