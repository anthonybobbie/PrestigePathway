using FluentValidation;
using PrestigePathway.Data.Models.ServiceOption;

namespace PrestigePathway.Data.Validators;

public class ServiceOptionPostRequestValidator : AbstractValidator<ServiceOptionPostRequest>
{
    public ServiceOptionPostRequestValidator()
    {
        RuleFor(x => x.OptionName).IsRequired().HasMaxLength(ValidationExtensions.NameMaxLength);
        RuleFor(x => x.ServiceTypeID).IsPositive();
        RuleFor(x => x.Description).HasMaxLength(ValidationExtensions.NotesMaxLength).When(x => !string.IsNullOrEmpty(x.Description));
    }
}