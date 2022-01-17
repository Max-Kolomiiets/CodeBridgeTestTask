using CodeBridgeTestTask.Core.Entities;
using CodeBridgeTestTask.DAL.Helpers;
using CodeBridgeTestTask.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeBridgeTestTask.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IDogsRepository _repository;
        public DogsController(IDogsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] SortingParams sortingParams, [FromQuery] PagingParams pagingParams)
        {
            return Ok(await _repository.GetDogsAsync(sortingParams, pagingParams));
        }

        /// <summary>
        /// Creates a Dog.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /dog
        ///     {
        ///        "name": "Mike",
        ///        "color": "black",
        ///        "tail_length": "4",
        ///        "weight": 13
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        /// <response code="409">If the item.name already exists</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [Route("/dog")]
        public async Task<IActionResult> CreateAsync(Dog item)
        {
            if (!ModelState.IsValid)            
                return BadRequest();
            if (await _repository.IsExists(item.Name))
                return Conflict(new { error = "The name is already in use" });
            
            await _repository.AddDogAsync(item);
            await _repository.SaveChangesAsync();
            return Created("/dogs", item);
        }
    }
}
