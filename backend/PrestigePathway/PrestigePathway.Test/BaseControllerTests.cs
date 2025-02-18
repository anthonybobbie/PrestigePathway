namespace PrestigePathway.Test
{
    using global::PrestigePathway.Api.Controllers;
    using global::PrestigePathway.Data.Abstractions;
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace PrestigePathway.Tests.Controllers
    {
        public class BaseControllerTests
        {
            private Mock<IService<TestEntity, TestResponse>> _mockService;
            private Mock<ILogger<TestController>> _mockLogger;
            private TestController _controller;

            [SetUp]
            public void Setup()
            {
                _mockService = new Mock<IService<TestEntity, TestResponse>>();
                _mockLogger = new Mock<ILogger<TestController>>();
                _controller = new TestController(_mockService.Object, _mockLogger.Object);
            }

            [Test]
            public async Task GetAll_Returns_OkResult()
            {
                // Arrange
                var entities = new List<TestResponse> { new TestResponse { Id = 1, Name = "Test Entity" } };
                _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(entities);

                // Act
                var result = await _controller.GetAll();

                // Assert
                var okResult = result as OkObjectResult;
                Assert.NotNull(okResult);
                Assert.AreEqual(200, okResult.StatusCode);
            }

            [Test]
            public async Task GetById_Returns_OkResult_WhenEntityExists()
            {
                // Arrange
                var entity = new TestResponse { Id = 1, Name = "Test Entity" };
                _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(entity);

                // Act
                var result = await _controller.GetById(1);

                // Assert
                var okResult = result as OkObjectResult;
                Assert.NotNull(okResult);
                Assert.AreEqual(200, okResult.StatusCode);
            }

            [Test]
            public async Task GetById_Returns_NotFound_WhenEntityDoesNotExist()
            {
                // Arrange
                _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync((TestResponse)null);

                // Act
                var result = await _controller.GetById(1);

                // Assert
                Assert.IsInstanceOf<NotFoundObjectResult>(result);
            }

            [Test]
            public async Task Create_Returns_CreatedAtAction()
            {
                // Arrange
                var createDto = new TestCreateDto { Name = "New Entity" };
                var entity = createDto.Adapt<TestEntity>();
                var response = new TestResponse { Id = 1, Name = "New Entity" };

                _mockService.Setup(s => s.AddAsync(It.IsAny<TestEntity>())).ReturnsAsync(It.IsAny<TestResponse>());
                _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(response);

                // Act
                var result = await _controller.Create(createDto);

                // Assert
                var createdAtActionResult = result.Result as CreatedAtActionResult;
                Assert.NotNull(createdAtActionResult);
                Assert.AreEqual(201, createdAtActionResult.StatusCode);
            }

            [Test]
            public async Task Update_Returns_Ok_WhenSuccessful()
            {
                // Arrange
                var entity = new TestEntity { Id = 1, Name = "Updated Entity" };
                _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(new TestResponse { Id = 1, Name = "Old Entity" });
                _mockService.Setup(s => s.UpdateAsync(It.IsAny<TestEntity>())).ReturnsAsync(It.IsAny<TestResponse>());

                // Act
                var result = await _controller.Update(1, entity);

                // Assert
                var okResult = result as OkObjectResult;
                Assert.NotNull(okResult);
                Assert.AreEqual(200, okResult.StatusCode);
            }

            [Test]
            public async Task Update_Returns_NotFound_WhenEntityDoesNotExist()
            {
                // Arrange
                _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync((TestResponse)null);

                // Act
                var result = await _controller.Update(1, new TestEntity { Id = 1 });

                // Assert
                Assert.IsInstanceOf<NotFoundObjectResult>(result);
            }

            [Test]
            public async Task Delete_Returns_NoContent_WhenSuccessful()
            {
                // Arrange
                _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(new TestResponse { Id = 1, Name = "Entity to Delete" });
                _mockService.Setup(s => s.DeleteAsync(1)).ReturnsAsync(true);

                // Act
                var result = await _controller.Delete(1);

                // Assert
                Assert.IsInstanceOf<NoContentResult>(result);
            }

            [Test]
            public async Task Delete_Returns_NotFound_WhenEntityDoesNotExist()
            {
                // Arrange
                _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync((TestResponse)null);

                // Act
                var result = await _controller.Delete(1);

                // Assert
                Assert.IsInstanceOf<NotFoundObjectResult>(result);
            }
       
            
        }

        // Test implementations
        public class TestEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class TestResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class TestCreateDto
        {
            public string Name { get; set; }
        }

        public class TestUpdateDto
        {
            public string Name { get; set; }
        }

        public class TestController : BaseController<TestEntity, IService<TestEntity, TestResponse>, TestResponse, TestCreateDto, TestUpdateDto>
        {
            public TestController(IService<TestEntity, TestResponse> service, ILogger<TestController> logger)
                : base(service, logger) { }

            protected override int GetEntityId(TestEntity entity) => entity.Id;
        }
    }

}