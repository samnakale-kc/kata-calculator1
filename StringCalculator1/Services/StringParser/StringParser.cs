using StringCalculator1.Services.DelimeterService;

namespace StringCalculator1.Services.StringParser
{
    public class StringParser : IStringParser
    {
        private readonly int[] _defaultListWhenEmptyString = new int[0];

        private readonly IDelimeterService _delimeterService;

        public StringParser(IDelimeterService delimeterService)
        {
            _delimeterService = delimeterService;
        }

        public int[] Parse(string input)
        {
            string cleanNumbers = input.Trim();

            if (cleanNumbers.Length == 0)
            {
                return _defaultListWhenEmptyString;
            }

            string[] numbersList = _delimeterService.GetNumbersFromDelimetedString(cleanNumbers);
            int listLength = numbersList.Length;
            int[] numbers = new int[listLength];
            var negativeNumbers = new List<string>();

            for (int i = 0; i < listLength; i++)
            {
                int number = int.Parse(numbersList[i]);
                numbers[i] = number;

                if (number < 0)
                {
                    negativeNumbers.Add(numbersList[i]);
                }
            }

            if (negativeNumbers.Count > 0)
            {
                string message = "negatives not allowed " + string.Join(",", negativeNumbers);
                throw new Exception(message);
            }

            return numbers;
        }
    }
}
