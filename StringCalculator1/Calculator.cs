using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator1
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var parser = new InputStringParser();
            string cleanNumbersInput = parser.Clean(numbers);
            List<int> inputNumbers = parser.ConvertCleanInputToArray(cleanNumbersInput);

            if (cleanNumbersInput.Length == 0)
            {
                return 0;
            }

            int[] negetiveNumbers = inputNumbers.Where(number => number < 0).ToArray();

            if (negetiveNumbers.Length > 0)
            {
                string negetiveNumbersList = String.Join(",", negetiveNumbers);
                throw new Exception("negatives not allowed " + negetiveNumbersList);
            }

            return inputNumbers
                .Where(number => number <= 1000)
                .Sum();
        }

    }
}
