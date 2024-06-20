using Common.Application.Validation;
using FluentValidation;

namespace Application.Product.Edit;
public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidator()
    {
        RuleFor(r => r.Name).NotEmpty().WithMessage(ValidationMessages.required("نام"));
        RuleFor(r => r.ManufacturerEmail).NotEmpty().WithMessage(ValidationMessages.required("ایمیل سازنده"));
        RuleFor(r => r.ManufacturerPhone).NotEmpty().WithMessage(ValidationMessages.required("تلفن سازنده"));
        RuleFor(r => r.ProduceDate).NotEmpty().WithMessage(ValidationMessages.required("تاریخ ساخت"));
    }
}