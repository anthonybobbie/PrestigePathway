using FluentValidation;
using PrestigePathway.Data.Models.Promotion;

namespace PrestigePathway.Data.Validators;

public class PromotionPostRequestValidator : AbstractValidator<PromotionPostRequest>
{
    public PromotionPostRequestValidator()
    {
        RuleFor(x => x.PromotionName).IsRequired().HasMaxLength(100);
        RuleFor(x => x.Description).HasMaxLength(500).When(x => !string.IsNullOrEmpty(x.Description));
        RuleFor(x => x.DiscountAmount).IsPositive();
        RuleFor(x => x.StartDate).NotEmpty().WithMessage(ValidationExtensions.RequiredMessage);
        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage(ValidationExtensions.RequiredMessage)
            .Must((promotion, endDate) => endDate > promotion.StartDate)
            .WithMessage(ValidationExtensions.EndAfterStartMessage);
    }
}