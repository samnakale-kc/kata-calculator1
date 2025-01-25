using System;
using StringCalculator1.Services;

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
            var parser = new StringParser();
            int[] numbersList = parser.Parse(numbers);

            int sum = 0;

            for (int i = 0; i < numbersList.Length; i++)
            {
                sum = sum + numbersList[i];
            }

            return sum;
        }
    }
}