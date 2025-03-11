using FluentValidation;
using PrestigePathway.Data.Models.Location;

namespace PrestigePathway.Data.Validators;

public class LocationPostRequestValidator : AbstractValidator<LocationPostRequest>
{
    public LocationPostRequestValidator()
    {
        RuleFor(x => x.LocationName).IsRequired().HasMaxLength(ValidationExtensions.NameMaxLength);
        RuleFor(x => x.Address).IsRequired().HasMaxLength(ValidationExtensions.AddressMaxLength);
        RuleFor(x => x.City).IsRequired().HasMaxLength(50);
        RuleFor(x => x.State).IsRequired().HasMaxLength(50);
        RuleFor(x => x.ZipCode).IsRequired().HasMaxLength(20);        
        RuleFor(x => x.Country).IsRequired().HasMaxLength(50);
    }
}