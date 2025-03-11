using FluentValidation;
using Mapster;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Data.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(5).WithMessage("Username must be at least 5 characters.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.");
        }
    }

    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(x => x.ClientID)
                .NotEmpty().WithMessage("Client ID is required.");
            RuleFor(x => x.ServiceID)
                .NotEmpty().WithMessage("Service ID is require.d");
            RuleFor(x => x.BookingDate)
                .NotEmpty().WithMessage("Booking date is required.");
            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Start time is required.");
            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("End time is required");
        }
    }
}