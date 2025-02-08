using FluentValidation;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer.Services
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
}