using StringCalculator1.Services.DelimeterService;

namespace StringCalculator1Tests.Services
{
    public class DelimeterServiceTests
    {
        private readonly DelimeterService _delimeterService;

        public DelimeterServiceTests()
        {
            _delimeterService = new DelimeterService();
        }

        [Fact]
        public void GivenCommaDelimetedInput_WhenGetNumbersFromDelimetedStringCalled_ThenReturnNumbers()
        {
            // Arrange
            string inputNumbers = "1,2";
            string[] expectedResult = ["1", "2"];

            // Act
            string[] result = _delimeterService.GetNumbersFromDelimetedString(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomDelimetedInput_WhenGetNumbersFromDelimetedStringCalled_ThenReturnNumbers()
        {
            // Arrange
            string inputNumbers = "//;\n1;2";
            string[] expectedResult = ["1", "2"];

            // Act
            string[] result = _delimeterService.GetNumbersFromDelimetedString(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomMultiCharacterDelimetedInput_WhenGetNumbersFromDelimetedStringCalled_ThenReturnNumbers()
        {
            // Arrange
            string inputNumbers = "//***\n1***2***3";
            string[] expectedResult = ["1", "2", "3"];

            // Act
            string[] result = _delimeterService.GetNumbersFromDelimetedString(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenMultipleCustomDelimetedInput_WhenGetNumbersFromDelimetedStringCalled_ThenReturnNumbers()
        {
            // Arrange
            string inputNumbers = "//[*][%]\n1*2%3";
            string[] expectedResult = ["1", "2", "3"];

            // Act
            string[] result = _delimeterService.GetNumbersFromDelimetedString(inputNumbers);

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
            string result = _delimeterService.GetCustomDelimeterFromFirstLine(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomMultiCharacterDelimetedInput_WhenGetCustomDelimeterFromFirstLineCalled_ThenReturnCustomDelimeter()
        {
            // Arrange
            string inputNumbers = "//***\n1***2***3";
            string expectedResult = "***";

            // Act
            string result = _delimeterService.GetCustomDelimeterFromFirstLine(inputNumbers);

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
            bool result = _delimeterService.InputHasFirstLineWithDelimeter(inputNumbers);

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
            bool result = _delimeterService.InputHasFirstLineWithDelimeter(inputNumbers);

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
            string[] result = _delimeterService.GetNumbersFromDelimetedString(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
