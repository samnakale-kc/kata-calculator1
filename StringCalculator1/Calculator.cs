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
            var inputNumbers = parser.ConvertCleanInputToArray(cleanNumbersInput);

            if (cleanNumbersInput.Length == 0)
            {
                return 0;
            }

            var negetiveNumbers = inputNumbers.Where(number => number < 0).ToArray();

            if (negetiveNumbers.Length > 0)
            {
                var negetiveNumbersList = String.Join(",", negetiveNumbers);
                throw new Exception("negatives not allowed " + negetiveNumbersList);
            }

            char[] stringDelimeters = [',', '\n'];
            return cleanNumbersInput.Split(stringDelimeters, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Sum();
        }

    }
}
