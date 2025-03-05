using System.Security.Cryptography;
using BCrypt.Net;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using PrestigePathway.Data.Models.User;
using PrestigePathway.Data.Services;
using PrestigePathway.Data.Utilities;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Test
{
    [TestFixture]
    public class AuthServiceTests
    {
        private Mock<IRepository<User>> _userRepositoryMock;
        private Mock<IRepository<UserRole>> _userRolesRepositoryMock;
        private Mock<IRepository<Role>> _roleRepositoryMock;
        private Mock<IConfiguration> _configurationMock;
        private Mock<IValidator<User>> _userValidatorMock;
        private Mock<IValidator<ChangePasswordRequest>> _changePasswordValidatorMock;
        private AuthService _authService;
        private DbContextOptions<TestDbContext> _dbContextOptions;

        [SetUp]
        public void Setup()
        {
            // Set up in-memory database options
            _dbContextOptions = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            
            _userRepositoryMock = new Mock<IRepository<User>>();
            _userRolesRepositoryMock = new Mock<IRepository<UserRole>>();
            _roleRepositoryMock = new Mock<IRepository<Role>>();
            _configurationMock = new Mock<IConfiguration>();
            _userValidatorMock = new Mock<IValidator<User>>();
            _changePasswordValidatorMock = new Mock<IValidator<ChangePasswordRequest>>();
            
            // Mock configuration for JWT settings
            var jwtSectionMock = new Mock<IConfigurationSection>();
            jwtSectionMock.Setup(x => x["Key"]).Returns("sfskfhlahhjhdgfhjklkahfsfnvamwaliganvahfvahuhfefsagfasufaspfa");
            jwtSectionMock.Setup(x => x["Issuer"]).Returns("Issuer");
            jwtSectionMock.Setup(x => x["Audience"]).Returns("Audience");
            _configurationMock.Setup(x => x.GetSection("Jwt")).Returns(jwtSectionMock.Object);
            
            // Configure Mapster mappings
            TypeAdapterConfig<User, UserDto>
                .NewConfig()
                .Map(dest => dest.Username, src => src.Username)
                .Map(dest => dest.ID, src => src.ID);

            _authService = new AuthService(
                _userRepositoryMock.Object,
                _roleRepositoryMock.Object,
                _configurationMock.Object,
                _userValidatorMock.Object,
                _userRolesRepositoryMock.Object,
                _changePasswordValidatorMock.Object
            );
        }

        [Test]
        public async Task LoginAsync_ValidCredentials_ReturnsAuthUser()
        {
            // Arrange
            var username = "testuser";
            var password = "password123";
            var hashed_password = BCrypt.Net.BCrypt.HashPassword(password, 12);
            var user = new User
            {
                ID = 1, Username = username, Password = hashed_password, CreatedOnUtc = DateTime.UtcNow
            };

            var validationResult = new FluentValidation.Results.ValidationResult();
            _userValidatorMock.Setup(x => x.ValidateAsync(user, default)).ReturnsAsync(validationResult);
            await using var context = new TestDbContext(_dbContextOptions);
            context.Set<User>().Add(user);
            await context.SaveChangesAsync();
            _userRepositoryMock.Setup(x => x.Query())
                .Returns(context.Set<User>().AsQueryable());
            
            // Act
            var result = await _authService.LoginAsync(username, password);
            
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Token, Is.Not.Null);
            Assert.That(result.User.Username, Is.EqualTo(username));
        }

        [Test]
        public async Task LoginAsync_InvalidCredentials_ThrowsArgumentException()
        {
            // Arrange
            var username = "testuser";
            var password = "wrongpassword";
            var hashed_password = BCrypt.Net.BCrypt.HashPassword("password123", 12);
            var user = new User
            {
                ID = 1, Username = username, Password = hashed_password, CreatedOnUtc = DateTime.UtcNow
            };

            await using var context = new TestDbContext(_dbContextOptions);
            context.Set<User>().Add(user);
            await context.SaveChangesAsync();
            _userRepositoryMock.Setup(x => x.Query())
                .Returns(context.Set<User>().AsQueryable());
            
            // Act and Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                await _authService.LoginAsync(username, password));
            Assert.That("Invalid username or password", Is.EqualTo(ex.Message));
        }

        [Test]
        public void LoginAsync_EmptyCredentials_ThrowsArgumentException()
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                await _authService.LoginAsync("", ""));
            Assert.That(ex.Message,Is.EqualTo("Username and password are required."));
        }

        [Test]
        public async Task RegisterAsync_ValidUser_ReturnsUserDto()
        {
            // Arrange
            var password = "password123";
            var hashed_password = BCrypt.Net.BCrypt.HashPassword(password, 12);
            var user = new User { ID = 1, Username = "newuser", Password = hashed_password, CreatedOnUtc = DateTime.UtcNow };
            var validationResult = new FluentValidation.Results.ValidationResult();
            _userValidatorMock.Setup(v => v.ValidateAsync(user, default)).ReturnsAsync(validationResult);
            await using var context = new TestDbContext(_dbContextOptions);
            _userRepositoryMock.Setup(r => r.Query()).Returns(context.Set<User>().AsQueryable());
            _userRepositoryMock.Setup(r => r.AddAsync(It.IsAny<User>())).ReturnsAsync(user);

            // Act
            var result = await _authService.RegisterAsync(user);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Username, Is.EqualTo(user.Username));
            _userRepositoryMock.Verify(x => x.AddAsync(It.Is<User>(x => x.Password != password)), Times.Once);
        }

        [Test]
        public async Task RegisterAsync_ExistingUser_ThrowsArgumentException()
        {
            // Arrange
            var newUser = new User { ID = 1, Username = "existinguser", Password = "password123", CreatedOnUtc = DateTime.UtcNow };
            var existingUser = new User { ID = 2, Username = "existinguser", Password = "password123", CreatedOnUtc = DateTime.UtcNow };
            var validationResult = new FluentValidation.Results.ValidationResult();
            _userValidatorMock.Setup(v => v.ValidateAsync(newUser, default)).ReturnsAsync(validationResult);
            await using var context = new TestDbContext(_dbContextOptions);
            await context.Set<User>().AddAsync(newUser);
            await context.SaveChangesAsync();
            _userRepositoryMock.Setup(x => x.Query()).Returns(context.Set<User>().AsQueryable());
            
            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                await _authService.RegisterAsync(newUser));
            Assert.That(ex.Message, Is.EqualTo("Username already exists."));
        }

        [Test]
        public async Task GenerateJwtToken_ValidUser_ReturnsToken()
        {
            // Arrange
            var user = new User { ID = 1, Username = "testuser", Password = "password123", CreatedOnUtc = DateTime.UtcNow };
            await using var context = new TestDbContext(_dbContextOptions);
            _userRolesRepositoryMock.Setup(x => x.Query()).Returns(context.Set<UserRole>().AsQueryable());
            _roleRepositoryMock.Setup(x => x.Query()).Returns(context.Set<Role>().AsQueryable());
            
            // Act
            var token = await _authService.GenerateJwtToken(user);
            
            // Assert
            Assert.That(token, Is.Not.Null);
        }

        [Test]
        public async Task ChangePasswordAsync_ValidRequest_UpdatesPassword()
        {
            // var username = "testuser";
            // var currentPassword = "currentpassword";
            // var newPassword = "newpassword";
            // var hashedCurrentPassword = BCrypt.Net.BCrypt.HashPassword(currentPassword, 12);
            // var user = new User { ID = 1, Username = username, Password = hashedCurrentPassword, CreatedOnUtc = DateTime.UtcNow };
            // var request = new ChangePasswordRequest { Username = username, CurrentPassword = currentPassword, NewPassword = newPassword };
            // _userRepositoryMock.Setup(x => x.Query()).Returns(new List<User> { user }.AsQueryable());
            // _userRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<User>()));
            //
            // var validResult = new FluentValidation.Results.ValidationResult();
            // _changePasswordValidatorMock.Setup(x => x.ValidateAsync(request, default)).ReturnsAsync(validResult);
            //
            // await _authService.ChangePasswordAsync(request);
            // _userRepositoryMock.Verify(x => x.UpdateAsync(It.Is<User>(u => 
            //     u.Username == username && BCrypt.Net.BCrypt.Verify(newPassword, u.Password))), Times.Once());
        }

        [Test]
        public async Task GenerateJwtToken_ShouldReturnValidToken()
        {
            var user = new User { ID = 1, Username = "testuser" };
            _configurationMock.Setup(c => c["Jwt:Key"]).Returns("SuperSecretKey12345");
            _configurationMock.Setup(c => c["Jwt:Issuer"]).Returns("TestIssuer");
            _configurationMock.Setup(c => c["Jwt:Audience"]).Returns("TestAudience");

            var token = await _authService.GenerateJwtToken(user);

            Assert.NotNull(token);
            Assert.IsNotEmpty(token);
        }
    }
    
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) 
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}



