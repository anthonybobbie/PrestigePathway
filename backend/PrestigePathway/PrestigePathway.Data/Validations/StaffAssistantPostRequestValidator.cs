using FluentValidation;
using PrestigePathway.Data.Models.StaffAssisstant;

namespace PrestigePathway.Data.Validators;

public class StaffAssistantPostRequestValidator : AbstractValidator<StaffAssisstantPostRequest>
{
    public StaffAssistantPostRequestValidator()
    {
        RuleFor(x => x.BookingID).IsPositive();
        RuleFor(x => x.StaffID).IsPositive();
        RuleFor(x => x.Notes).HasMaxLength(ValidationExtensions.NotesMaxLength).When(x => !string.IsNullOrEmpty(x.Notes));
        RuleFor(x => x.AssignmentDate).NotEmpty().WithMessage(ValidationExtensions.RequiredMessage);
    }
}