using CalculatorAPI.Data;
using CalculatorAPI.DTOs;
using CalculatorAPI.Models;
using CalculatorAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalculatorAPI.Controllers
{
    [Route("api/calculator")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculationRepository repository;

        public CalculatorController(ICalculationRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CalculationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }

            var result = request.FirstNumber + request.SecondNumber;
            var calculation = new Calculation
            {
                FirstNumber = request.FirstNumber,
                SecondNumber = request.SecondNumber,
                Operator = "add",
                Result = result
            };

            repository.AddCalculation(calculation);

            return Ok(new CalculationResponse { Result = result });
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] CalculationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }

            var result = request.FirstNumber - request.SecondNumber;
            var calculation = new Calculation
            {
                FirstNumber = request.FirstNumber,
                SecondNumber = request.SecondNumber,
                Operator = "subtract",
                Result = result
            };

            repository.SubtractCalculation(calculation);

            return Ok(new CalculationResponse { Result = result });
        }

        [HttpPost("multiply")]
        public IActionResult Multiply([FromBody] CalculationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }

            var result = request.FirstNumber * request.SecondNumber;
            var calculation = new Calculation
            {
                FirstNumber = request.FirstNumber,
                SecondNumber = request.SecondNumber,
                Operator = "multiply",
                Result = result
            };
            repository.MultiplyCalculation(calculation);

            return Ok(new CalculationResponse { Result = result });
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] CalculationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }

            if (request.SecondNumber == 0)
            {
                return BadRequest("Division by zero is not allowed");
            }

            var result = request.FirstNumber / request.SecondNumber;
            var calculation = new Calculation
            {
                FirstNumber = request.FirstNumber,
                SecondNumber = request.SecondNumber,
                Operator = "divide",
                Result = result
            };

            repository.DivideCalculation(calculation);

            return Ok(new CalculationResponse { Result = result });
        }

        [HttpGet("history")]
        public IActionResult GetCalculationHistory()
        {
            try
            {
          
                var history = repository.GetCalculationHistory(5);
                return Ok(history);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred while fetching calculation history: {ex}");

                return StatusCode(500, "An error occurred while fetching calculation history.");
            }
        }

    }


}
