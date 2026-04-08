

using System.Text.RegularExpressions;

namespace DialogueLibrary
{
    public class Dialogue
    {
        /// <summary>
        /// The possible actions that the program can take after an operation is complete.
        /// </summary>
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
        /// <summary>
        /// Requests a number from the user. The user may also type "h" to select a value from the Calculation History list.
        /// </summary>
        /// <param name="calculationHistoryResults">List of previous calculation results.</param>
        /// <returns>The parsed input or selected result.</returns>
        public double RequestNumericInput(List<double> calculationHistoryResults)
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

        /// <summary>
        /// Requests an operation from the user. This method only accepts valid operations (a, s, m, or d).
        /// </summary>
        /// <returns>The selected operation. (a, s, m, or d)</returns>
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
        /// <summary>
        /// Print the possible operations to the dialogue.
        /// </summary>
        public void PrintOperations()
        {
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");
        }

        /// <summary>
        /// Prints the Result history to the dialogue.
        /// </summary>
        /// <param name="calculationHistoryResults">List of previous calculation results.</param>
        /// <returns>The Result associated with the selected historical result.</returns>
        public double RequestResultHistorySelection(List<double> calculationHistoryResults)
        {
            PrintLineSeparator();
            Console.WriteLine("Previous Results");
            for (int i = 0; i < calculationHistoryResults.Count(); i++)
            {
                Console.WriteLine($"Index: {i}, Result: {calculationHistoryResults[i]}");
            }

            Console.WriteLine("Type an index to recall the result: ");

            string? value = Console.ReadLine();
            int cleanIndex;
            while (!int.TryParse(value, out cleanIndex) || cleanIndex < 0 || cleanIndex >= calculationHistoryResults.Count)
            {
                Console.WriteLine($"This is not a valid input. Please provide an integer between 0 and {calculationHistoryResults.Count - 1}: ");
                value = Console.ReadLine();
            }

            Console.WriteLine($"You have selected: {calculationHistoryResults[cleanIndex]}");
            PrintLineSeparator();

            return calculationHistoryResults[cleanIndex];
        }
        /// <summary>
        /// Allows the user to clear history, end the program, or continue.
        /// </summary>
        /// <returns>The selected action defined in the PostOpSelections enum.</returns>
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
        /// <summary>
        /// Prints a line separator for a clean and uniform experience.
        /// </summary>
        public void PrintLineSeparator() => Console.WriteLine("------------------------\n");
    }
}
