using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator1
{
    public class StringParser
    {

        private readonly int[] _defaultListWhenEmptyString = new int[0];

        public int[] parse(string input)
        {
            string cleanNumbers = input.Trim();

            if (cleanNumbers.Length == 0)
            {
                return _defaultListWhenEmptyString;
            }

            string[] numbersList = cleanNumbers.Split(',');
            int listLength = numbersList.Length;
            int[] numbers = new int[listLength];

            for (int i = 0; i < listLength; i++)
            {
                int number = int.Parse(numbersList[i]);
                numbers[i] = number;
            }

            return numbers;
        }
    }
}
