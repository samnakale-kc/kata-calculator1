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
        public string GetDelimeter();
        public bool StringHasCustomDelimeter(string input);
        public string RemoveFirstLineFromCustomDelimetedInput(string input);
        public string GetCustomDelimeter(string input);
    }
}
