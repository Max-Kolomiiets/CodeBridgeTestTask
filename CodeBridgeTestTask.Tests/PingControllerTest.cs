using CodeBridgeTestTask.API.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeBridgeTestTask.Tests
{
    public class PingControllerTest
    {
        private readonly Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();

        public PingControllerTest()
        {
            mockConfig.Setup(x => x.GetSection("DogService")["Version"])
                .Returns("1.0.1");   
        }

        [Fact]
        public void Ping_ShouldReturnStringVersion()
        {
            PingController controller = new PingController(mockConfig.Object);
            var result = controller.Ping();
            Assert.NotNull(result);
        }
    }
}
