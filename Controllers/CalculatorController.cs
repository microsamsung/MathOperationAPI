using MathOperationAPI.Model;
using MathOperationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MathOperationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        /// <summary>
        /// Performs the specified arithmetic operation with the given operands.
        /// </summary>
        /// <param name="request">The request model containing operation type and operands.</param>
        /// <returns>The result of the arithmetic operation.</returns>
        /// <response code="200">Returns the result of the operation.</response>
        /// <response code="400">If the input is invalid or an exception occurs.</response>
        /// <response code="500">Internal server error.</response>
        [SwaggerOperation(Summary = "Creates a new arithmetic operation.")]
        [SwaggerResponse(200, "Arithmetic operation done successfully")]
        [SwaggerResponse(400, "Invalid request")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpGet ("Calculate")]
        public async Task<IActionResult> Get([FromQuery] CalculatorRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, error = "Invalid input data" });
            }

            try
            {
                var result = await _calculatorService.PerformOperationAsync(request.OperationType, request.FirstOperand, request.SecondOperand);
                return Ok(new { success = true, data = new { result } });
            }
            catch (Exception ex)
            {
                // Log exception details if necessary
                // Logger.LogError(ex, "An error occurred while performing the operation");
                return StatusCode(500, new { success = false, error = "Internal server error" });
            }
        }
    }
}