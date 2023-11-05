namespace CalculatorAPI.DTOs
{
    public class CalculationRequest
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operator { get; set; }
    }
}
