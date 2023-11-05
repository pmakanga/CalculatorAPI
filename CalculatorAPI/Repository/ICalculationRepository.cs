using CalculatorAPI.Models;

namespace CalculatorAPI.Repository
{
    public interface ICalculationRepository
    {
        Calculation AddCalculation(Calculation calculation);
        Calculation SubtractCalculation(Calculation calculation);
        Calculation MultiplyCalculation(Calculation calculation);
        Calculation DivideCalculation(Calculation calculation);
        List<Calculation> GetCalculationHistory(int count);
    }
}
