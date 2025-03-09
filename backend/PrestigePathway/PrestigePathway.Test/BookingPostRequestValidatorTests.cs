using FluentValidation;
using Microsoft.Extensions.Configuration;
using Moq;
using PrestigePathway.Data.Models.Booking;
using PrestigePathway.Data.Validators;

namespace PrestigePathway.Test;

[TestFixture]
public class BookingPostRequestValidatorTests
{
    private IValidator<BookingPostRequest> _validator;
    private Mock<IConfiguration> _configurationMock;

    [SetUp]
    public void SetUp()
    {
        _configurationMock = new Mock<IConfiguration>();
        var jwtSectionMock = new Mock<IConfigurationSection>();
        jwtSectionMock.Setup(x => x["Key"])
            .Returns("ajsdfshwqhitwkuiouyq8w3rwqgnsafjsihwe984tw0py9sahfklhaf8uwur90875hkfajfkfaslasf@hk");
        jwtSectionMock.Setup(x => x["Issuer"]).Returns("Issuer");
        jwtSectionMock.Setup(x => x["Audience"]).Returns("Audience");
        _configurationMock.Setup(x => x.GetSection("Jwt")).Returns(jwtSectionMock.Object);
        
        _validator = new BookingPostRequestValidator(_configurationMock.Object);
    }

    [Test]
    public void ValidateBooking_PassesValidation()
    {
        var booking = new BookingPostRequest
        {
            ClientID = 1,
            ServiceID = 2,
            BookingDate = DateTime.UtcNow.AddDays(1),
            StartTime = DateTime.UtcNow.AddHours(2),
            EndTime = DateTime.UtcNow.AddHours(3),
            Status = "Pending",
            Notes = "Test Booking",
            CreatedOnUtc = DateTime.UtcNow
        };

        var result = _validator.Validate(booking);
        Assert.That(result.IsValid, Is.True);
    }
}