using System.Text.RegularExpressions;
using CalculatorLibrary;
using DialogueLibrary;

class Program
{
    static void Main(string[] args)
    {
        Dialogue.PostOpSelections postOp = Dialogue.PostOpSelections.Continue;

        Dialogue dialogue = new Dialogue();
        Calculator calculator = new();

        while (postOp != Dialogue.PostOpSelections.End)
        {
            List<double> previousResults = calculator.GetCalculationHistoryResults();
            double numInput1 = dialogue.RequestNumericInput(previousResults);
            double numInput2 = dialogue.RequestNumericInput(previousResults);
            string op = dialogue.RequestOperation();

            try
            {
                calculator.DoOperation(numInput1, numInput2, op);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }
            dialogue.PrintLineSeparator();

            postOp = dialogue.RequestPostOperationInstruction();
            if (postOp == Dialogue.PostOpSelections.Clear) calculator.ClearCalculationHistory();
        }

        calculator.Shutdown();
        return;
    }


}