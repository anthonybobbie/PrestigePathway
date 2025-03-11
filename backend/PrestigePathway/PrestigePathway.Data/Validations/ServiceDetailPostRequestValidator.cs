using FluentValidation;
using PrestigePathway.Data.Models.ServiceDetail;

namespace PrestigePathway.Data.Validators;

public class ServiceDetailPostRequestValidator : AbstractValidator<ServiceDetailPostRequest>
{
    public ServiceDetailPostRequestValidator()
    {
        RuleFor(x => x.ServiceName).IsRequired().HasMaxLength(ValidationExtensions.NameMaxLength);
        RuleFor(x => x.Description).HasMaxLength(ValidationExtensions.NotesMaxLength).When(x => !string.IsNullOrEmpty(x.Description));
        RuleFor(x => x.Price).IsPositive();
        RuleFor(x => x.ServiceTypeID).IsPositive();
        RuleFor(x => x.ServiceOptionID).IsPositive();
        RuleFor(x => x.ServicePartnerID).IsPositive();
    }
}