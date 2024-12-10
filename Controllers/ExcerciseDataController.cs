using ExcerciseApi.Data;
using ExcerciseApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ExcerciseApi.Controllers
{
    [Route("api/excercise_data")]
    [ApiController]
    public class ExcerciseDataController : ControllerBase
    {
        private readonly IExcerciseDataRepository _repository;

        /// <summary>
        /// Initializes a new instance of the ExcerciseDataController.
        /// </summary>
        /// <param name="repository">The excercise data repository.</param>
        public ExcerciseDataController(IExcerciseDataRepository repository) => _repository = repository;

        /// <summary>
        /// Queries data by customer between two dates.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="startDate">The starting date filter.</param>
        /// <param name="endDate">The ending date filter.</param>
        /// <returns>The selected data.</returns>
        /// <response code="200">The query completed successfully.</response>
        /// <response code="400">One or more parameters failed validation.</response>
        /// <response code="500">Unable to process request due to an error.</response>
        [HttpGet]
        [Route("customers/{customerId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ExcerciseData>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetByCustomerBetweenDates(int customerId, [FromQuery]DateTime startDate, [FromQuery]DateTime endDate)
        {
            // sanity checks
            if (customerId <= 0)
            {
                return StatusCode(400, "Invalid customer identifier.");
            }

            if (startDate > endDate)
            {
                return StatusCode(400, "Start date must be before ending date.");
            }

            try
            {
                var excerciseData = _repository.GetByCustomerBetweenDates(customerId, startDate, endDate);

                return Ok(excerciseData);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error processing request.");
            }
        }
    }
}
