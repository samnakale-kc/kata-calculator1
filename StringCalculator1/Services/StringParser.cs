using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator1.Services
{
    public class StringParser : IStringParser
    {

        private readonly int[] _defaultListWhenEmptyString = new int[0];

        public int[] Parse(string input)
        {
            string cleanNumbers = input.Trim();

            if (cleanNumbers.Length == 0)
            {
                return _defaultListWhenEmptyString;
            }

            string[] numbersList = cleanNumbers.Split([',', '\n'], StringSplitOptions.RemoveEmptyEntries);
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
