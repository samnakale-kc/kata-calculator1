using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator1
{
    public class Calculator
    {
        public int Add(string numbers)
        {

            string cleanNumbersInput = numbers.Trim();

            if (cleanNumbersInput.Length == 0)
            {
                return 0;
            }

            string[] numbersList = cleanNumbersInput.Split(',');
            int[] integerNumbersList = numbersList.Select(int.Parse).ToArray();

            return integerNumbersList.Sum();
        }

    }
}
