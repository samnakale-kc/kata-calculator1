using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator1.Services.Delimeter
{
    public class DelimeterService
    {

        private readonly string _customDelimeterNewLineStartString = @"//";

        public string[] GetNumbersFromDelimetedString(string numbers)
        {
            string[] delimetersToSplitStringBy = [",", "\n"];

            if (StringHasCustomDelimeter(numbers))
            {
                string customDelimeter = GetCustomDelimeter(numbers);
                numbers = RemoveFirstLineFromCustomDelimetedInput(numbers);
                delimetersToSplitStringBy = [customDelimeter];
            }

            return numbers.Split(delimetersToSplitStringBy, StringSplitOptions.RemoveEmptyEntries);
        }

        public string GetCustomDelimeter(string input)
        {
            return input.Split('\n')[0].Replace(@"//", "");
        }

        public bool StringHasCustomDelimeter(string input)
        {
            if (input.StartsWith(_customDelimeterNewLineStartString) && input.Contains('\n'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RemoveFirstLineFromCustomDelimetedInput(string input)
        {
            if (!StringHasCustomDelimeter(input))
            {
                return input;
            }

            var stringSections = input.Split('\n').ToList();
            stringSections.RemoveAt(0); // Removes the first line directly

            return string.Join("\n", stringSections);
        }
    }
}
