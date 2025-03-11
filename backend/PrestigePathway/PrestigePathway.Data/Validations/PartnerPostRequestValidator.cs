using FluentValidation;
using PrestigePathway.Data.Models.Partner;

namespace PrestigePathway.Data.Validators;

public class PartnerPostRequestValidator : AbstractValidator<PartnerPostRequest>
{
    public PartnerPostRequestValidator()
    {
        RuleFor(x => x.PartnerName).IsRequired().HasMaxLength(ValidationExtensions.NameMaxLength);
        RuleFor(x => x.Email).IsRequired().IsValidEmail().HasMaxLength(ValidationExtensions.EmailMaxLength);
        RuleFor(x => x.Address).HasMaxLength(ValidationExtensions.AddressMaxLength).When(x => !string.IsNullOrEmpty(x.Address));
        RuleFor(x => x.PhoneNumber).HasMaxLength(11).When(x => !string.IsNullOrEmpty(x.PhoneNumber));
    }
}