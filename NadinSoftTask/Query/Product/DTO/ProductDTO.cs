using Common.Domain.ValueObjects;
using System;

namespace Query.Product.DTO;
public class ProductDTO
{
    public long ProductId { get; set; }
    public long UserId { get; set; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
    public string ManufacturerEmail { get; set; }
    public string ManufacturerPhone { get; set; }
    public DateTime ProduceDate { get; set; }
}