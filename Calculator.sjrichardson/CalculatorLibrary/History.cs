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

        public void RecordHistory()
        {
            using (StreamWriter file = File.CreateText(CalculationHisoryFilePath))
            {
                JsonSerializer serializer = new();
                serializer.Serialize(file, calculationHistory);
            }
        }

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

        public void ClearHistory()
        {
            calculationHistory.Clear();
            RecordHistory();
            Console.WriteLine("History cleared...");
        }

        public void AddToCalculationHistory(Calculation calculation) => calculationHistory.Add(calculation);

        // probably need some validation here or above
        public double RecallPreviousResult(int resultIndex) => calculationHistory[resultIndex].Result;

        public List<(int, double)> GetPreviousResults()
        {
            List<(int idx, double result)> historyList = new List<(int idx, double result)>();
            for (int i = 0; i < calculationHistory.Count; i++)
            {
                historyList.Add((i, calculationHistory[i].Result));
            }

            return historyList;

        }
    }
}
