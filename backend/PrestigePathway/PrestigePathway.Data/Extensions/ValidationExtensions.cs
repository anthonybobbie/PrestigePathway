using System.IdentityModel.Tokens.Jwt;
using System.Text;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace PrestigePathway.Data.Validators;

public static class ValidationExtensions 
{
    // Common error messages
    public const string RequiredMessage = "{PropertyName} is required.";
    public const string MaxLengthMessage = "{PropertyName} must not exceed {MaxLength} characters.";
    public const string EmailMessage = "{PropertyName} must be a valid email address.";
    public const string PhoneMessage = "{PropertyName} must be a valid phone number.";
    public const string FutureDateMessage = "{PropertyName} must be in the future.";
    public const string PositiveNumberMessage = "{PropertyName} must be greater than 0.";
    public const string EndAfterStartMessage = "End date must be after start date.";
    public const string RatingRangeMessage = "Rating must be between 1 and 5.";
    public const string StatusMessage = "Status must be 'Pending', 'Confirmed', 'Cancelled' or 'Completed'.";
    public const string InvalidTokenMessage = "A valid authentication token is required.";
    public const int NotesMaxLength = 500;
    public const int NameMaxLength = 20;
    public const int EmailMaxLength = 20;
    public const int AddressMaxLength = 200;
    
    // Common validation rules
    public static IRuleBuilderOptions<T, string> IsRequired<T>(this IRuleBuilder<T, string> rule) =>
        rule.NotEmpty().WithMessage(RequiredMessage);
    
    public static IRuleBuilderOptions<T, string> HasMaxLength<T>(this IRuleBuilder<T, string> rule, int maxLength) =>
        rule.MaximumLength(maxLength).WithMessage(MaxLengthMessage);

    public static IRuleBuilderOptions<T, string> IsValidEmail<T>(this IRuleBuilder<T, string> rule) =>
        rule.EmailAddress().WithMessage(EmailMessage).HasMaxLength(EmailMaxLength);

    public static IRuleBuilderOptions<T, string> IsValidPhoneNumber<T>(this IRuleBuilder<T, string> rule) =>
        rule.Matches(@"^\+?[1-9]\d{1,14}$").WithMessage(PhoneMessage);

    public static IRuleBuilderOptions<T, DateTime> IsFutureDate<T>(this IRuleBuilder<T, DateTime> rule) =>
        rule.Must(date => date > DateTime.UtcNow).WithMessage(FutureDateMessage);

    public static IRuleBuilderOptions<T, int> IsPositive<T>(this IRuleBuilder<T, int> rule) =>
        rule.GreaterThan(0).WithMessage(PositiveNumberMessage);

    public static IRuleBuilderOptions<T, decimal> IsPositive<T>(this IRuleBuilder<T, decimal> rule) =>
        rule.GreaterThan(0).WithMessage(PositiveNumberMessage);

    public static IRuleBuilderOptions<T, DateTime> IsRequired<T>(this IRuleBuilder<T, DateTime> rule) =>
        rule.NotEmpty().WithMessage(RequiredMessage);

    public static IRuleBuilderOptions<T, string> IsValidToken<T>(this IRuleBuilder<T, string> rule,
        IConfiguration configuration)
    {
        return rule
            .NotEmpty().WithMessage(RequiredMessage)
            .Must(token => ValidateJwtToken(token, configuration))
            .WithMessage(InvalidTokenMessage);
    }

    private static bool ValidateJwtToken(string token, IConfiguration configuration)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero // No tolerance for expired token
            }, out var validatedToken);

            return true;
        }
        catch
        {
            return false;
        }
    }
}