using FluentValidation;
using PrestigePathway.Data.Models.Payment;

namespace PrestigePathway.Data.Validators;

public class PaymentPostRequestValidator : AbstractValidator<PaymentPostRequest>
{
    public PaymentPostRequestValidator()
    {
        RuleFor(x => x.BookingID).IsPositive();
        RuleFor(x => x.Amount).IsPositive();
        RuleFor(x => x.PaymentDate).NotEmpty().WithMessage(ValidationExtensions.RequiredMessage);
        RuleFor(x => x.TransactionID).HasMaxLength(50).When(x => !string.IsNullOrEmpty(x.TransactionID));
        RuleFor(x => x.Status).IsRequired();
    }
}