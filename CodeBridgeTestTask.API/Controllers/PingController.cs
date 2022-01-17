using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBridgeTestTask.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IConfiguration _config;
        public PingController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public string Ping()
        {
            return $"Dogs house service. Version {_config.GetSection("DogService")["Version"]}";
        }
    }
}
