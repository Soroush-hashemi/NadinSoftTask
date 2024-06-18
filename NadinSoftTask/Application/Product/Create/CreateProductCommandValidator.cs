using Common.Application.Validation;
using FluentValidation;

namespace Application.Product.Create;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(r => r.Name).NotEmpty().WithMessage(ValidationMessages.required("نام"));
        RuleFor(r => r.ManufacturerEmail).NotEmpty().WithMessage(ValidationMessages.required("ایمیل سازنده"));
        RuleFor(r => r.ManufacturerPhone).NotEmpty().WithMessage(ValidationMessages.required("تلفن سازنده"));
        RuleFor(r => r.IsAvailable).NotEmpty().WithMessage(ValidationMessages.required("موجود است ؟"));
        RuleFor(r => r.ProduceDate).NotEmpty().WithMessage(ValidationMessages.required("تاریخ ساخت"));
    }
}