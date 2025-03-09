using FluentValidation;
using PrestigePathway.Data.Models.Staff;

namespace PrestigePathway.Data.Validators;

public class StaffPostRequestValidator : AbstractValidator<StaffPostRequest>
{
    public StaffPostRequestValidator()
    {
        RuleFor(x => x.FirstName).IsRequired().HasMaxLength(ValidationExtensions.NameMaxLength);
        RuleFor(x => x.LastName).IsRequired().HasMaxLength(ValidationExtensions.NameMaxLength);
        RuleFor(x => x.Email).IsValidEmail().When(x => !string.IsNullOrEmpty(x.Email));
        RuleFor(x => x.PhoneNumber).IsValidPhoneNumber().When(x => !string.IsNullOrEmpty(x.PhoneNumber));
    }
}