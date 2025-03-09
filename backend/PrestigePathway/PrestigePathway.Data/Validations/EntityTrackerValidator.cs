using FluentValidation;
using PrestigePathway.DataAccessLayer.Abstractions;

namespace PrestigePathway.Data.Validators;

// Base validator for entities and IEntityTracker
public abstract class EntityTrackerValidator<T> : AbstractValidator<T> where T : IEntityTracker
{
    protected EntityTrackerValidator()
    {
        RuleFor(x => x.CreatedOnUtc)
            .NotEmpty().WithMessage(ValidationExtensions.RequiredMessage);
        
        RuleFor(x => x.ModifiedOnUtc)
            .Must(date => !date.HasValue || date > DateTime.UtcNow)
            .WithMessage("Modified date must be in the future if provided.");
    }
}