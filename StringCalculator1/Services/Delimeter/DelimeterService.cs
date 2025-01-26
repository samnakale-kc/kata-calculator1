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
        private readonly string[] _defaultdelimeters = [",", "\n"];

        public string[] GetNumbersFromDelimetedString(string numbers)
        {
            string[] delimetersToSplitStringBy = _defaultdelimeters;
            bool inputHasFirstLineWithDelimeter = InputHasFirstLineWithDelimeter(numbers);
            bool inputHasCustomDelimeter = InputHasCustomDelimeter(numbers);

            if (!inputHasFirstLineWithDelimeter && inputHasCustomDelimeter)
            {
                string customDelimeter = GetCustomDelimeterFromInputWithoutFirstLine(numbers);
                delimetersToSplitStringBy = [customDelimeter];
            }

            if (inputHasFirstLineWithDelimeter)
            {
                string customDelimeter = GetCustomDelimeterFromFirstLine(numbers);
                numbers = RemoveFirstLineFromCustomDelimetedInput(numbers);
                delimetersToSplitStringBy = [customDelimeter];
            }

            return numbers.Split(delimetersToSplitStringBy, StringSplitOptions.RemoveEmptyEntries);
        }

        public string GetCustomDelimeterFromFirstLine(string input)
        {
            return input.Split('\n')[0].Replace(@"//", "");
        }

        public string GetCustomDelimeterFromInputWithoutFirstLine(string input)
        {
            foreach (char currentInputCharacter in input)
            {
                if (!Char.IsDigit(currentInputCharacter))
                {
                    return currentInputCharacter.ToString();
                }
            }

            return string.Empty; // Technically, we should never reach here
        }

        public bool InputHasCustomDelimeter(string input)
        {
            var defaultDelimetersList = _defaultdelimeters.ToList();

            foreach(char currentInputCharacter in input)
            {
                bool currentCharIsNotContainedInDefaultDelimeters = defaultDelimetersList.Contains(currentInputCharacter.ToString());
                if (!Char.IsDigit(currentInputCharacter) && !currentCharIsNotContainedInDefaultDelimeters)
                {
                    return true;
                }
            }

            return false;
        }

        public bool InputHasFirstLineWithDelimeter(string input)
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
            if (!InputHasFirstLineWithDelimeter(input))
            {
                return input;
            }

            var stringSections = input.Split('\n').ToList();
            stringSections.RemoveAt(0); // Removes the first line directly

            return string.Join("\n", stringSections);
        }
    }
}
