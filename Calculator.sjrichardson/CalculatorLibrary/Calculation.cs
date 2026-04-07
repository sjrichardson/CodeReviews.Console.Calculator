

using System.Text.Json.Serialization;

namespace CalculatorLibrary
{
    public class Calculation
    {
        public double Operand1 { get; }
        public double Operand2 { get; }
        public string? Operation { get; }
        public double Result { get; }

        [JsonConstructor]
        public Calculation(double operand1, double operand2, string? operation, double result)
        {
            this.Operand1 = operand1;
            this.Operand2 = operand2;
            this.Operation = operation;
            this.Result = result;
        }

        public override string ToString() => $"{Operand1} {Operation} {Operand2} = {Result}";
    }
}
