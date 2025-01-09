using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator1
{
    public class InputStringParser
    {
        public string Clean(string numbers)
        {
            string cleanNumbersInput = numbers.Trim();

            Match match = Regex.Match(cleanNumbersInput, @"\/\/(.+)\n*");

            if (match.Success)
            {
                string customDelimeter = match.Groups[1].Value;
                string firstLine = match.Value;
                cleanNumbersInput = cleanNumbersInput.Replace(firstLine, String.Empty);
                cleanNumbersInput = cleanNumbersInput.Replace(customDelimeter, ",");
            }

            Match matchWithoutFirstLine = Regex.Match(cleanNumbersInput, @"([^\d-]+)");

            if (matchWithoutFirstLine.Success)
            {
                string customDelimeter = matchWithoutFirstLine.Groups[1].Value;
                string firstLine = matchWithoutFirstLine.Value;
                cleanNumbersInput = cleanNumbersInput.Replace(customDelimeter, ",");
            }

            return cleanNumbersInput;
        }

        public List<int> ConvertCleanInputToArray(string input)
        {
            char[] stringDelimeters = [',', '\n'];

            return input.Split(stringDelimeters, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
