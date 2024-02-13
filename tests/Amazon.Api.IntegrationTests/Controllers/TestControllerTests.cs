using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Api.Controllers;
using Xunit;

namespace Amazon.Api.IntegrationTests.Controllers
{
    public class TestControllerTests
    {
        [Fact]
        public void Get_ReturnsOkResult_WithExpectedMessage()
        {
            // Arrange
            var controller = new TestController();

            // Act
            var result = controller.Get() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(" hiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii", result.Value);
        }
    }
}
