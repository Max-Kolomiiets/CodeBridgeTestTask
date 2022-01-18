using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CodeBridgeTestTask.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IConfiguration _config;
        public PingController(IConfiguration config) => _config = config;

        [HttpGet]
        public string Ping() => $"Dogs house service. Version {_config.GetSection("DogService")["Version"]}";
    }
}
