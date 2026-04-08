
namespace CalculatorLibrary
{
    public class Calculator
    {
        History calculationHistory;
        public Calculator()
        {
            calculationHistory = new History();
        }

        public void DoOperation(double num1, double num2, string op)
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

            if (double.IsNaN(result))
            {
                Console.WriteLine("This operation will result in a mathematical error.\n");
            }
            else
            {
                Console.WriteLine("Your result: {0:0.##}\n", result);
                calculationHistory.AddToCalculationHistory(new Calculation(num1, num2, operation, result));
            }
        }

        public List<(int, double)> GetCalculationHistoryResults() => calculationHistory.GetPreviousResults();

        public void ClearCalculationHistory() => calculationHistory.ClearHistory();
        public void Shutdown() => calculationHistory.RecordHistory();



    }
}
