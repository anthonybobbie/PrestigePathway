using System.Data;
using FluentValidation;
using PrestigePathway.Data.Models.Client;

namespace PrestigePathway.Data.Validators;

public class ClientPostRequestValidator : AbstractValidator<ClientPostRequest>
{
    public ClientPostRequestValidator()
    {
        RuleFor(x => x.FirstName).IsRequired().HasMaxLength(20);
        RuleFor(x => x.LastName).IsRequired().HasMaxLength(20);
        RuleFor(x => x.Email)
            .IsValidEmail().When(x => !string.IsNullOrEmpty(x.Email));
        RuleFor(x => x.PhoneNumber)
            .IsValidPhoneNumber().When(x => !string.IsNullOrEmpty(x.PhoneNumber));
        RuleFor(x => x.Address)
            .HasMaxLength(200).When(x => !string.IsNullOrEmpty(x.Address));
        RuleFor(x => x.ClientType)
            .HasMaxLength(20).When(x => !string.IsNullOrEmpty(x.ClientType));
        RuleFor(x => x.RegistrationDate)
            .NotEmpty().WithMessage(ValidationExtensions.RequiredMessage);
        RuleFor(x => x.Notes)
            .HasMaxLength(ValidationExtensions.NotesMaxLength).When(x => !string.IsNullOrEmpty(x.Notes));
    }
}