using FluentValidation;
using PrestigePathway.Data.Utilities;

namespace PrestigePathway.Data.Validators
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            //RuleFor(x => x.NewPassword)
            //    .NotEmpty().WithMessage("New password is require.")
            //    .MinimumLength(6).WithMessage("New password must be at least 6 characters long.")
            //    .Matches("[A-Z]").WithMessage("New password must contain at least one uppercase letter.")
            //    .Matches("[a-z]").WithMessage("New password must contain at least one lowercase letter.")
            //    .Matches("[0-9]").WithMessage("New password must contain at least one digit.")
            //    .Matches("[^a-zA-Z0-9]]").WithMessage("New password must contain at least one special character.");
        }
    }
}
