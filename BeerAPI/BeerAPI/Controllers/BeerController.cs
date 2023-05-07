using BeerAPI.Extensions;
using BeerAPI.Interfaces;
using BeerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BeerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequestObjValidationFilter]
    public class BeerController : ControllerBase
    {
        private readonly IBeerRepository _repository;

        public BeerController(IBeerRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all beers from database
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Beers fetched successfully</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(OkResponse<IEnumerable<Beer>>))]
        [ProducesResponseType(500, Type = typeof(ExceptionResponse<string>))]
        public IActionResult GetAllBeers()
        {
            var result = _repository.GetBeers();

            return Ok(result);
        }

        /// <summary>
        /// Filters beers from database
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <response code="200">Beers filtered successfully</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("filter")]
        [ProducesResponseType(200, Type = typeof(OkResponse<IEnumerable<Beer>>))]
        [ProducesResponseType(500, Type = typeof(ExceptionResponse<string>))]
        public IActionResult FilterBeers([FromQuery] string filter)
        {
            var result = _repository.FilterBeers(filter);

            return Ok(result);
        }

        /// <summary>
        /// Creates a new beer
        /// </summary>
        /// <param name="beer"></param>
        /// <returns></returns>
        /// <response code="200">Beer added successfully in database</response>
        /// <response code="400">Bad request object</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(OkResponse<Beer>))]
        [ProducesResponseType(400, Type = typeof(ExceptionResponse<Dictionary<string, List<string>>>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public IActionResult AddBeer([FromBody] Beer beer)
        {
            var result = _repository.AddBeer(beer);

            return Ok(result);
        }

        /// <summary>
        /// Updates beer rating
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Beer updated successfully</response>
        /// <response code="400">Bad request object</response>
        /// <response code="500">Internal server error</response>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(OkResponse<Beer>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public IActionResult UpdateBeer([FromBody] UpdateBeer model)
        {
            var result = _repository.UpdateBeer(model);

            return Ok(result);
        }
    }
}