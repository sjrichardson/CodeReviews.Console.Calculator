

namespace CalculatorLibrary
{
    public class Calculation
    {
        public double Operand1 { get; }
        public double Operand2 { get; }
        public string? Operation { get; }
        public double Result { get; }
        public Calculation(double num1, double num2, string? operation, double result)
        {
            this.Operand1 = num1;
            this.Operand2 = num2;
            this.Operation = operation;
            this.Result = result;
        }

        public override string ToString()
        {
            return $"{Operand1} {Operation} {Operand2} = {Result}";
        }
    }
}
