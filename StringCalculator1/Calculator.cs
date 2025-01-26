using System;
using StringCalculator1.Services.StringParser;

namespace StringCalculator1
{
    public class Calculator
    {
        private readonly IStringParser _parser;

        public Calculator(IStringParser parser)
        {
            _parser = parser;
        }

        public int Add(string numbers)
        {
            int[] numbersList = _parser.Parse(numbers);

            int sum = 0;

            for (int i = 0; i < numbersList.Length; i++)
            {
                sum = sum + numbersList[i];
            }

            return sum;
        }
    }
}