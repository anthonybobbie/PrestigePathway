using FluentValidation;
using Microsoft.Extensions.Configuration;
using PrestigePathway.Data.Models.Booking;

namespace PrestigePathway.Data.Validators;

public class BookingPostRequestValidator : AbstractValidator<BookingPostRequest>
{
    private readonly IConfiguration _configuration;
    public BookingPostRequestValidator(IConfiguration configuration)
    {
        _configuration = configuration;
        RuleFor(x => x.ClientID).IsPositive();
        RuleFor(x => x.ServiceID).IsPositive();
        RuleFor(x => x.Notes).HasMaxLength(ValidationExtensions.NotesMaxLength).When(x => !string.IsNullOrEmpty(x.Notes));
        RuleFor(x => x.BookingDate).IsRequired().IsFutureDate();
        RuleFor(x => x.StartTime).IsRequired().IsFutureDate();
        RuleFor(x => x.EndTime)
            .IsRequired()
            .IsFutureDate()
            .Must((booking, endTime) => endTime > booking.StartTime);
        RuleFor(x => x.Status)
            .IsRequired()
            .HasMaxLength(10)
            .Must(status => new[] { "Pending", "Confirmed", "Cancelled", "Completed" }.Contains(status))
            .WithMessage(ValidationExtensions.StatusMessage);
        RuleFor(x => x.Notes).HasMaxLength(ValidationExtensions.NotesMaxLength).When(x => !string.IsNullOrEmpty(x.Notes));
    }
}