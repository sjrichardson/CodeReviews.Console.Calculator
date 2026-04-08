

using System.Text.RegularExpressions;

namespace DialogueLibrary
{
    public class Dialogue
    {
        public enum PostOpSelections
        {
            Continue,
            End,
            Clear
        }

        public Dialogue()
        {
            Console.WriteLine("Console Calculator in C#\r");
            PrintLineSeparator();
        }
        public double RequestNumericInput(List<(int, double)> calculationHistoryResults)
        {

            Console.Write("Type a number, (or h) and then press Enter: ");
            string? numInput = Console.ReadLine();
            double cleanNum = 0;

            while (!double.TryParse(numInput, out cleanNum))
            {
                if (numInput != null && numInput == "h")
                {
                    if (calculationHistoryResults.Count == 0)
                    {
                        Console.Write("No history found. Please provide an integer value: ");
                        numInput = Console.ReadLine();
                        continue;
                    }
                    return RequestResultHistorySelection(calculationHistoryResults);
                }
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput = Console.ReadLine();
            }

            return cleanNum;
        }

        public string RequestOperation()
        {
            PrintOperations();

            string? op = Console.ReadLine();
            // Keep requesting operation until input is not null and matches an existing operation
            while (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
                PrintOperations();
                op = Console.ReadLine();
            }
            return op;
        }

        public void PrintOperations()
        {
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");
        }

        public double RequestResultHistorySelection(List<(int idx, double result)> calculationHistoryResults)
        {
            PrintLineSeparator();
            Console.WriteLine("Previous Results");
            foreach ((int idx, double result) in calculationHistoryResults)
            {
                Console.WriteLine($"Index: {idx}, Result: {result}");
            }

            Console.WriteLine("Type an index to recall the result: ");

            string? value = Console.ReadLine();
            int cleanIndex;
            while (!int.TryParse(value, out cleanIndex) || cleanIndex < 0 || cleanIndex >= calculationHistoryResults.Count)
            {
                Console.WriteLine($"This is not a valid input. Please provide an integer between 0 and {calculationHistoryResults.Count - 1}: ");
                value = Console.ReadLine();
            }

            Console.WriteLine($"You have selected: {calculationHistoryResults[cleanIndex].result}");
            PrintLineSeparator();

            return calculationHistoryResults[cleanIndex].result;
        }

        public PostOpSelections RequestPostOperationInstruction()
        {
            // Wait for the user to respond before closing.
            Console.Write("Press 'n' and Enter to close the app, 'c' to clear history, or press any other key and Enter to continue: ");
            var choice = Console.ReadLine();
            if (choice == "n") return PostOpSelections.End;
            if (choice == "c") return PostOpSelections.Clear;

            Console.WriteLine("\n"); // Friendly linespacing.

            return PostOpSelections.Continue;
        }
        public void PrintLineSeparator() => Console.WriteLine("------------------------\n");
    }
}
