using CalculatorAPI.Controllers;
using CalculatorAPI.DTOs;
using CalculatorAPI.Models;
using CalculatorAPI.Repository;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI.Test.Controllers
{
    public class CalculatorControllerTests
    {
        private readonly ICalculationRepository _calculationRepository;
        public CalculatorControllerTests()
        {
            _calculationRepository = A.Fake<ICalculationRepository>();
        }

        [Fact]

        public void CalculatorController_GetCalculationHistory_ReturnOk()
        {
            // Arrange
            var controller = new CalculatorController(_calculationRepository);
            var fakeHistory = new List<Calculation>
            {
                new Calculation { Id = 1, FirstNumber = 5, SecondNumber = 3, Operator = "add", Result = 8 },
                new Calculation { Id = 2, FirstNumber = 10, SecondNumber = 2, Operator = "subtract", Result = 8 },
                new Calculation { Id = 3, FirstNumber = 4, SecondNumber = 2, Operator = "multiply", Result = 8 },
            };

            A.CallTo(() => _calculationRepository.GetCalculationHistory(5))
                .Returns(fakeHistory);

            // Act
            var result = controller.GetCalculationHistory();

            // Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().NotBeNull().And.BeOfType<List<Calculation>>();
            var history = okResult.Value as List<Calculation>;
            history.Should().HaveCount(3);
        }

        [Fact]
        public void CalculatorController_Add_ReturnOk()
        {
            // Arrange
            var controller = new CalculatorController(_calculationRepository);
            var request = new CalculationRequest { FirstNumber = 5, SecondNumber = 3 };

            A.CallTo(() => _calculationRepository.AddCalculation(A<Calculation>.That.Matches(calc =>
                calc.FirstNumber == request.FirstNumber &&
                calc.SecondNumber == request.SecondNumber &&
                calc.Operator == "add"))) // Check the 'Operator' property
                .Invokes((Calculation calculation) =>
                {
                    calculation.Id = 1; // Simulate the addition of the calculation
                });

            // Act
            var result = controller.Add(request);

            // Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().NotBeNull().And.BeOfType<CalculationResponse>();
            var response = okResult.Value as CalculationResponse;
            response.Result.Should().Be(8);
        }


        [Fact]
        public void CalculatorController_Subtract_ReturnOk()
        {
            // Arrange
            var controller = new CalculatorController(_calculationRepository);
            var request = new CalculationRequest { FirstNumber = 5, SecondNumber = 3 };

            A.CallTo(() => _calculationRepository.SubtractCalculation(A<Calculation>.That.Matches(calc =>
                calc.FirstNumber == request.FirstNumber &&
                calc.SecondNumber == request.SecondNumber &&
                calc.Operator == "subtract"))) // Check the 'Operator' property
                .Invokes((Calculation calculation) =>
                {
                    calculation.Id = 1; // Simulate the addition of the calculation
                });

            // Act
            var result = controller.Subtract(request);

            // Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().NotBeNull().And.BeOfType<CalculationResponse>();
            var response = okResult.Value as CalculationResponse;
            response.Result.Should().Be(2); // The result of subtracting 3 from 5
        }


        [Fact]
        public void CalculatorController_Multiply_ReturnOk()
        {
            // Arrange
            var controller = new CalculatorController(_calculationRepository);
            var request = new CalculationRequest { FirstNumber = 5, SecondNumber = 3 };

            A.CallTo(() => _calculationRepository.MultiplyCalculation(A<Calculation>.That.Matches(calc =>
                calc.FirstNumber == request.FirstNumber &&
                calc.SecondNumber == request.SecondNumber &&
                calc.Operator == "multiply"))) // Check the 'Operator' property
                .Invokes((Calculation calculation) =>
                {
                    calculation.Id = 1; // Simulate the multiplication of the calculation
                });

            // Act
            var result = controller.Multiply(request);

            // Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().NotBeNull().And.BeOfType<CalculationResponse>();
            var response = okResult.Value as CalculationResponse;
            response.Result.Should().Be(15); // Adjust the expected result as needed
        }

        [Fact]
        public void CalculatorController_Divide_ReturnOk()
        {
            // Arrange
            var controller = new CalculatorController(_calculationRepository);
            var request = new CalculationRequest { FirstNumber = 6, SecondNumber = 3 }; // Non-zero divisor

            A.CallTo(() => _calculationRepository.DivideCalculation(A<Calculation>.That.Matches(calc =>
                calc.FirstNumber == request.FirstNumber &&
                calc.SecondNumber == request.SecondNumber &&
                calc.Operator == "divide"))) // Check the 'Operator' property
                .Invokes((Calculation calculation) =>
                {
                    calculation.Id = 1; // Simulate the division of the calculation
                });

            // Act
            var result = controller.Divide(request);

            // Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().NotBeNull().And.BeOfType<CalculationResponse>();
            var response = okResult.Value as CalculationResponse;
            response.Result.Should().Be(2); // Adjust the expected result as needed
        }

    }

}
