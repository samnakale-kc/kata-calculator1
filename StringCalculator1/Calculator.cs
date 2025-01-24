using System;

namespace StringCalculator1
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var parser = new StringParser();
            int[] numbersList = parser.parse(numbers);

            int sum = 0;

            for (int i = 0; i < numbersList.Length; i++)
            {
                sum = sum + numbersList[i];
            }

            return sum;
        }
    }
}