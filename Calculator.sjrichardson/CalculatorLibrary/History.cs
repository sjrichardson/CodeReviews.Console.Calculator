using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public class History
    {
        List<Calculation> calculationHistory;
        private const string CalculationHisoryFilePath = "Calculator.json";

        public History()
        {
            calculationHistory = new List<Calculation>();
            LoadHistory();
        }
        /// <summary>
        /// Save the Calculation History list to the History file.
        /// </summary>
        public void RecordHistory()
        {
            using (StreamWriter file = File.CreateText(CalculationHisoryFilePath))
            {
                JsonSerializer serializer = new();
                serializer.Serialize(file, calculationHistory);
            }
        }

        /// <summary>
        /// Load the Calculation History list from the History file.
        /// </summary>
        private void LoadHistory()
        {
            if (File.Exists(CalculationHisoryFilePath))
            {
                string text = File.ReadAllText(CalculationHisoryFilePath);
                calculationHistory = JsonConvert.DeserializeObject<List<Calculation>>(text) ?? new();
            }
            else
            {
                calculationHistory = new();
            }

        }
        /// <summary>
        /// Clear the Calculation History list and save to the History file.
        /// </summary>
        public void ClearHistory()
        {
            calculationHistory.Clear();
            RecordHistory();
            Console.WriteLine("History cleared...");
        }

        /// <summary>
        /// Add new calculation to the Calculation History list.
        /// </summary>
        /// <param name="calculation">The Calculation to add to the list.</param>
        public void AddToCalculationHistory(Calculation calculation) => calculationHistory.Add(calculation);

        // probably need some validation here or above
        /// <summary>
        /// Returns the result value of the Calculation at the given index. Input validation is performed before this point so we do not validate here.
        /// </summary>
        /// <param name="resultIndex">Index of the Result in the Calculation History list.</param>
        /// <returns></returns>
        public double RecallPreviousResult(int resultIndex) => calculationHistory[resultIndex].Result;

        /// <summary>
        /// Returns the Result fields of each entry in the Calculation History list.
        /// </summary>
        /// <returns>A list of Result values.</returns>
        public List<double> GetPreviousResults() => calculationHistory.Select(calc => calc.Result).ToList();
    }
}
