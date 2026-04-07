using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DialogueLibrary
{
    public class Dialogue
    {

        public Dialogue()
        {
            Console.WriteLine("Console Calculator in C#\r");
            PrintLineSeparator();
        }
        public double RequestNumericInput()
        {

            Console.Write("Type a number, and then press Enter: ");
            string? numInput = Console.ReadLine();

            double cleanNum = 0;
            while (!double.TryParse(numInput, out cleanNum))
            {
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

        public bool RequestPostOperationInstruction()
        {
            // Wait for the user to respond before closing.
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") return true;

            Console.WriteLine("\n"); // Friendly linespacing.
            return false;
        }
        public void PrintLineSeparator() => Console.WriteLine("------------------------\n");
    }
}
