using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalculator1;
using StringCalculator1.Services;
using StringCalculator1.Services.Delimeter;

namespace StringCalculator1Tests.Services
{
    public class DelimeterServiceTests
    {
        private readonly DelimeterService _delimeter;

        public DelimeterServiceTests()
        {
            _delimeter = new DelimeterService();
        }

        [Fact]
        public void GivenCommaDelimetedInput_WhenParseCalled_ThenReturnNumbers()
        {
            // Arrange
            string inputNumbers = "1,2";
            string[] expectedResult = ["1", "2"];

            // Act
            string[] result = _delimeter.GetNumbersFromDelimetedString(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomDelimetedInput_WhenParseCalled_ThenReturnNumbers()
        {
            // Arrange
            string inputNumbers = "//;\n1;2";
            string[] expectedResult = ["1", "2"];

            // Act
            string[] result = _delimeter.GetNumbersFromDelimetedString(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomDelimetedInput_WhenGetCustomDelimeterFromFirstLineCalled_ThenReturnCustomDelimeter()
        {
            // Arrange
            string inputNumbers = "//;\n1;2";
            string expectedResult = ";";

            // Act
            string result = _delimeter.GetCustomDelimeterFromFirstLine(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomDelimetedInput_WhenStringInputHasFirstLineWithDelimeterCalled_ThenReturnTrue()
        {
            // Arrange
            string inputNumbers = "//;\n1;2";
            bool expectedResult = true;

            // Act
            bool result = _delimeter.InputHasFirstLineWithDelimeter(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCommaDelimetedInput_WhenStringInputHasFirstLineWithDelimeterCalled_ThenReturnFalse()
        {
            // Arrange
            string inputNumbers = "1,2";
            bool expectedResult = false;

            // Act
            bool result = _delimeter.InputHasFirstLineWithDelimeter(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomDelimetedInputWithoutFirstLine_WhenGetNumbersFromDelimetedStringCalled_ThenReturnSum()
        {
            // Arrange
            string inputNumbers = "1x2x5";
            string[] expectedResult = ["1","2","5"];

            // Act
            string[] result = _delimeter.GetNumbersFromDelimetedString(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
