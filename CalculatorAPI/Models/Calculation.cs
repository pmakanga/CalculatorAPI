namespace CalculatorAPI.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string? Operator { get; set; }
        public double Result { get; set; }
    }
}
