using FluentValidation;
using PrestigePathway.Data.Models.Testimonial;

namespace PrestigePathway.Data.Validators;

public class TestimonialPostRequestValidator : AbstractValidator<TestimonialPostRequest>
{
    public TestimonialPostRequestValidator()
    {
        RuleFor(x => x.ClientID).IsPositive();
        RuleFor(x => x.Content).IsRequired().HasMaxLength(ValidationExtensions.NotesMaxLength);
        RuleFor(x => x.TestimonialDate).NotEmpty().WithMessage(ValidationExtensions.RequiredMessage);
        RuleFor(x => x.Rating).InclusiveBetween(1, 5).WithMessage(ValidationExtensions.RatingRangeMessage);
    }
}