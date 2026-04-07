using System.Text.RegularExpressions;
using CalculatorLibrary;
using DialogueLibrary;

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;

        Dialogue dialogue = new Dialogue();
        Calculator calculator = new();

        while (!endApp)
        {
            double result = 0;
            double numInput1 = dialogue.RequestNumericInput();
            double numInput2 = dialogue.RequestNumericInput();
            string op = dialogue.RequestOperation();

            try
            {
                result = calculator.DoOperation(numInput1, numInput2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else Console.WriteLine("Your result: {0:0.##}\n", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }
            dialogue.PrintLineSeparator();

            endApp = dialogue.RequestPostOperationInstruction();
        }

        return;
    }


}