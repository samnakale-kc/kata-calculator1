using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator1.Services.Delimeter
{
    public interface IDelimeterService
    {
        public string[] GetNumbersFromDelimetedString(string numbers);
        public string GetCustomDelimeterFromFirstLine(string input);
        public string GetCustomDelimeterFromInputWithoutFirstLine(string input);
        public bool InputHasCustomDelimeter(string input);
        public bool InputHasFirstLineWithDelimeter(string input);
        public string RemoveFirstLineFromCustomDelimetedInput(string input);
    }
}
