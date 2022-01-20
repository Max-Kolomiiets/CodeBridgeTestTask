using CodeBridgeTestTask.API.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace CodeBridgeTestTask.Tests
{
    public class PingControllerTest
    {
        private readonly Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
        private readonly string version = "1.0.1";

        public PingControllerTest()
        {
            mockConfig.Setup(x => x.GetSection("DogService")["Version"])
                .Returns(version);   
        }

        [Fact]
        public void Ping_ShouldReturnStringVersion()
        {
            PingController controller = new PingController(mockConfig.Object);
            var result = controller.Ping();
            Assert.NotNull(result);
            Assert.Contains(version, result);
        }
    }
}
