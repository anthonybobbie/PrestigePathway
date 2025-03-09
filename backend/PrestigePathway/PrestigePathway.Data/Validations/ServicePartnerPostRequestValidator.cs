using FluentValidation;
using PrestigePathway.Data.Models.ServicePartner;

namespace PrestigePathway.Data.Validators;

public class ServicePartnerPostRequestValidator : AbstractValidator<ServicePartnerPostRequest>
{
    public ServicePartnerPostRequestValidator()
    {
        RuleFor(x => x.PartnerName).IsRequired().HasMaxLength(ValidationExtensions.NameMaxLength);
        RuleFor(x => x.ServiceTypeID).IsPositive();
        RuleFor(x => x.ServiceOptionID).IsPositive();
        RuleFor(x => x.ContactEmail).IsValidEmail().When(x => !string.IsNullOrEmpty(x.ContactEmail));
        RuleFor(x => x.ContactPhone).IsValidPhoneNumber().When(x => !string.IsNullOrEmpty(x.ContactPhone));
        RuleFor(x => x.Address).HasMaxLength(ValidationExtensions.AddressMaxLength).When(x => !string.IsNullOrEmpty(x.Address));
    }
}