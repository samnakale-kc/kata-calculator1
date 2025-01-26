using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator1.Services.DelimeterService
{
    public class DelimeterService
    {

        private readonly string _customDelimeterNewLineStartString = @"//";
        private readonly string[] _defaultdelimeters = [",", "\n"];
        private readonly string _multiDelimeterStartString = "[";
        private readonly string _multiDelimeterEndString = "]";
        private readonly string _newLineCharacter = "\n";

        public string[] GetNumbersFromDelimetedString(string numbers)
        {
            string[] delimetersToSplitStringBy = _defaultdelimeters;
            bool inputHasFirstLineWithDelimeter = InputHasFirstLineWithDelimeter(numbers);
            bool inputHasCustomDelimeter = InputHasCustomDelimeter(numbers);
            bool inputHasMultipleDelimeters = InputHasMultipleDelimeters(numbers);

            if (!inputHasFirstLineWithDelimeter && inputHasCustomDelimeter)
            {
                string customDelimeter = GetCustomDelimeterFromInputWithoutFirstLine(numbers);
                delimetersToSplitStringBy = [customDelimeter];
            }
            else if (inputHasMultipleDelimeters)
            {
                string[] customDelimeter = GetCustomDelimetersFromInputWithMuliDelimeters(numbers);
                numbers = RemoveFirstLineFromCustomDelimetedInput(numbers);
                delimetersToSplitStringBy = customDelimeter;
            }
            else if (inputHasFirstLineWithDelimeter)
            {
                string customDelimeter = GetCustomDelimeterFromFirstLine(numbers);
                numbers = RemoveFirstLineFromCustomDelimetedInput(numbers);
                delimetersToSplitStringBy = [customDelimeter];
            }

            return numbers.Split(delimetersToSplitStringBy, StringSplitOptions.RemoveEmptyEntries);
        }

        public bool InputHasMultipleDelimeters(string input)
        {
            string startsWith = _customDelimeterNewLineStartString + _multiDelimeterStartString;
            string endOfDelimeterLine = _multiDelimeterEndString + _newLineCharacter;

            if (input.StartsWith(startsWith) && input.Contains(_multiDelimeterEndString))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public string[] GetCustomDelimetersFromInputWithMuliDelimeters(string input)
        {
            string firstLine = input.Split(_newLineCharacter)[0].Replace(_customDelimeterNewLineStartString, string.Empty);

            string[] delimeters = firstLine.Split(_multiDelimeterEndString, StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < delimeters.Length; i++)
            {
                string delimeter = delimeters[i];
                string cleanDelimeter = delimeter.Replace(_multiDelimeterStartString, string.Empty).Replace(_multiDelimeterEndString, string.Empty);

                delimeters[i] = cleanDelimeter;
            }

            return delimeters;
        }

        public string GetCustomDelimeterFromFirstLine(string input)
        {
            return input.Split(_newLineCharacter)[0].Replace(_customDelimeterNewLineStartString, string.Empty);
        }

        public string GetCustomDelimeterFromInputWithoutFirstLine(string input)
        {
            foreach (char currentInputCharacter in input)
            {
                if (!char.IsDigit(currentInputCharacter))
                {
                    return currentInputCharacter.ToString();
                }
            }

            return string.Empty; // Technically, we should never reach here
        }

        public bool InputHasCustomDelimeter(string input)
        {
            var defaultDelimetersList = _defaultdelimeters.ToList();

            foreach (char currentInputCharacter in input)
            {
                bool currentCharIsNotContainedInDefaultDelimeters = defaultDelimetersList.Contains(currentInputCharacter.ToString());
                if (!char.IsDigit(currentInputCharacter) && !currentCharIsNotContainedInDefaultDelimeters)
                {
                    return true;
                }
            }

            return false;
        }

        public bool InputHasFirstLineWithDelimeter(string input)
        {
            if (input.StartsWith(_customDelimeterNewLineStartString) && input.Contains(_newLineCharacter))
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

            var stringSections = input.Split(_newLineCharacter).ToList();
            stringSections.RemoveAt(0); // Removes the first line directly

            return string.Join(_newLineCharacter, stringSections);
        }
    }
}
