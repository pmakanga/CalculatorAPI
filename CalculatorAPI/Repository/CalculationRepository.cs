using System;
using System.Collections.Generic;
using System.Linq;
using CalculatorAPI.Data;
using CalculatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculatorAPI.Repository
{
    public class CalculationRepository : ICalculationRepository
    {
        private readonly CalculatorDbContext _context;

        public CalculationRepository(CalculatorDbContext context)
        {
            _context = context;
        }

        public Calculation AddCalculation(Calculation calculation)
        {
            try
            {
                calculation.Operator = "add";
                calculation.Result = calculation.FirstNumber + calculation.SecondNumber;

                _context.Calculations.Add(calculation);
                _context.SaveChanges();

                return calculation;
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exceptions
                // You can log the exception for debugging purposes
                throw new Exception("An error occurred while adding the calculation.", ex);
            }
        }

        public Calculation SubtractCalculation(Calculation calculation)
        {
            try
            {
                calculation.Operator = "subtract";
                calculation.Result = calculation.FirstNumber - calculation.SecondNumber;

                _context.Calculations.Add(calculation);
                _context.SaveChanges();

                return calculation;
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exceptions
                // You can log the exception for debugging purposes
                throw new Exception("An error occurred while subtracting the calculation.", ex);
            }
        }

        public Calculation MultiplyCalculation(Calculation calculation)
        {
            try
            {
                calculation.Operator = "multiply";
                calculation.Result = calculation.FirstNumber * calculation.SecondNumber;

                _context.Calculations.Add(calculation);
                _context.SaveChanges();

                return calculation;
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exceptions
                // You can log the exception for debugging purposes
                throw new Exception("An error occurred while multiplying the calculation.", ex);
            }
        }

        public Calculation DivideCalculation(Calculation calculation)
        {
            try
            {
                calculation.Operator = "divide";
                if (calculation.SecondNumber == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                calculation.Result = calculation.FirstNumber / calculation.SecondNumber;

                _context.Calculations.Add(calculation);
                _context.SaveChanges();

                return calculation;
            }
            catch (DivideByZeroException ex)
            {
                // Handle divide by zero exception
                // You can log the exception for debugging purposes
                throw new Exception("An error occurred while dividing the calculation.", ex);
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exceptions
                // You can log the exception for debugging purposes
                throw new Exception("An error occurred while dividing the calculation.", ex);
            }
        }

        public List<Calculation> GetCalculationHistory(int count)
        {
            try
            {
                return _context.Calculations
                    .OrderByDescending(c => c.Id)
                    .Take(count)
                    .ToList();
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exceptions
                // You can log the exception for debugging purposes
                throw new Exception("An error occurred while fetching calculation history.", ex);
            }
        }
    }
}
