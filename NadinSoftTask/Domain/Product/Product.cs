using Common.Domain.Bases;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;

namespace Domain.Product;
public class Product : BaseEntity
{
    public long UserId { get; set; }
    public string Name { get; private set; }
    public bool IsAvailable { get; private set; }
    public string ManufacturerEmail { get; private set; }
    public PhoneNumber ManufacturerPhone { get; private set; }
    public DateTime ProduceDate { get; private set; }

    public Product(string name, bool isAvailable, string manufacturerEmail,
        PhoneNumber manufacturerPhone, DateTime produceDate)
    {
        Guard(name , manufacturerEmail);
        Name = name;
        IsAvailable = isAvailable;
        ManufacturerEmail = manufacturerEmail;
        ManufacturerPhone = manufacturerPhone;
        ProduceDate = produceDate;
    }

    public void Edit(string name, bool isAvailable, string manufacturerEmail,
        PhoneNumber manufacturerPhone, DateTime produceDate)
    {
        Guard(name, manufacturerEmail);
        Name = name;
        IsAvailable = isAvailable;
        ManufacturerEmail = manufacturerEmail;
        ManufacturerPhone = manufacturerPhone;
        ProduceDate = produceDate;
    }

    private void Guard(string name, string manufacturerEmail)
    {
        NullOrEmptyException.CheckString(name, nameof(name));
        NullOrEmptyException.CheckString(manufacturerEmail, nameof(manufacturerEmail));
    }
}