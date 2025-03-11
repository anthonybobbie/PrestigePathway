using FluentValidation;
using PrestigePathway.Data.Models.ServiceType;

namespace PrestigePathway.Data.Validators;

public class ServiceTypePostRequestValidator : AbstractValidator<ServiceTypePostRequest>
{
    public ServiceTypePostRequestValidator()
    {
        RuleFor(x => x.TypeName).IsRequired().HasMaxLength(ValidationExtensions.NameMaxLength);
    }
}