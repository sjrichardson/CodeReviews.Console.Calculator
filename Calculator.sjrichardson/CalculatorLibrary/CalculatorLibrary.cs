using System.Diagnostics;
using Newtonsoft.Json;
namespace CalculatorLibrary
{
    public class CalculatorLibrary
    {

        List<Calculation> calculationHistory;
        private const string CalculationHisoryFilePath = "Calculator.json";
        public CalculatorLibrary()
        {
            calculationHistory = new List<Calculation>();
        }

        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
            // Use a switch statement to do the math.
            string? operation = null;
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    operation = "Add";
                    break;
                case "s":
                    result = num1 - num2;
                    operation = "Subtract";
                    break;
                case "m":
                    result = num1 * num2;
                    operation = "Multiply";
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        operation = "Divide";
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }

            calculationHistory.Add(new Calculation(num1, num2, operation, result));


            return result;
        }


        public void RecordHistory()
        {
            using (StreamWriter file = File.CreateText(CalculationHisoryFilePath))
            {
                JsonSerializer serializer = new();
                serializer.Serialize(file, calculationHistory);
            }
        }

        public void LoadHistory()
        {
            if (File.Exists(CalculationHisoryFilePath))
            {
                calculationHistory = JsonConvert.DeserializeObject<List<Calculation>>(File.ReadAllText(CalculationHisoryFilePath)) ?? new();
            }
            else
            {
                calculationHistory = new();
            }

        }
    }
}
