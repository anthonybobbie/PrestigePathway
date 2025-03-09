using FluentValidation;
using PrestigePathway.Data.Models.ServiceLocation;

namespace PrestigePathway.Data.Validators;

public class ServiceLocationPostRequestValidator : AbstractValidator<ServiceLocationPostRequest>
{
    public ServiceLocationPostRequestValidator()
    {
        RuleFor(x => x.ServiceID).IsPositive();
        RuleFor(x => x.LocationID).IsPositive();
    }
}