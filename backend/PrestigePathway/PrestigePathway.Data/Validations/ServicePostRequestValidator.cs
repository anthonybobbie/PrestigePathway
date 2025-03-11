using FluentValidation;
using PrestigePathway.Data.Models.Service;

namespace PrestigePathway.Data.Validators;

public class ServicePostRequestValidator : AbstractValidator<ServicePostRequest>
{
    public ServicePostRequestValidator()
    {
        RuleFor(x => x.ServiceName).IsRequired().HasMaxLength(ValidationExtensions.NameMaxLength);
        RuleFor(x => x.Description).HasMaxLength(ValidationExtensions.NotesMaxLength).When(x => !string.IsNullOrEmpty(x.Description));
        RuleFor(x => x.Price).IsPositive();
    }
}