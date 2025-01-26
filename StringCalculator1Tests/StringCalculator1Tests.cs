using Moq;
using StringCalculator1;
using StringCalculator1.Services.StringParser;

namespace StringCalculator1Tests
{
    public class StringCalculator1Tests
    {
        private Mock<IStringParser> _mockParser;
        private Calculator _calculator;

        public StringCalculator1Tests()
        {
            _mockParser = new Mock<IStringParser>();
            _calculator = new Calculator(_mockParser.Object);
        }

        [Fact]
        public void GivenEmptyString_WhenAddCalled_ThenReturnZero()
        {
            // Arrange
            string numbers = "";
            const int expectedResult = 0;
            int[] parserResponse = new int[0]; 
            _mockParser.Setup(s => s.Parse(string.Empty)).Returns(parserResponse);

            // Act
            int result = _calculator.Add(numbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void GivenOneOrTwoNumbers_WhenAddCalled_ThenReturnSum(string numbers, int expectedResult)
        {
            // Arrange
            _mockParser.Setup(s => s.Parse("1")).Returns([1]);
            _mockParser.Setup(s => s.Parse("1,2")).Returns([1, 2]);

            // Act
            int result = _calculator.Add(numbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenUnknownAmountOfNumbers_WhenAddCalled_ThenReturnSum()
        {
            // Arrange
            string inputNumbers = "1,2,3,4,5,6,7";
            int expectedResult = 28;
            int[] expectedParsedResult = [1, 2, 3, 4, 5, 6, 7];
            _mockParser.Setup(s => s.Parse(inputNumbers)).Returns(expectedParsedResult);

            // Act
            int result = _calculator.Add(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenInputStringWithNewLineInsteadOfComma_WhenAddCalled_ThenReturnSum()
        {
            // Arrange
            string inputNumbers = "1\n2";
            int expectedResult = 3;
            int[] expectedParsedResult = [1, 2];
            _mockParser.Setup(s => s.Parse(inputNumbers)).Returns(expectedParsedResult);

            // Act
            int result = _calculator.Add(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomDelimetedInput_WhenAddCalled_ThenReturnSum()
        {
            // Arrange
            string inputNumbers = "//;\n1;2";
            int expectedResult = 3;
            int[] expectedParsedResult = [1, 2];
            _mockParser.Setup(s => s.Parse(inputNumbers)).Returns(expectedParsedResult);

            // Act
            int result = _calculator.Add(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomDelimetedInputWithoutFirstLine_WhenAddCalled_ThenReturnSum()
        {
            // Arrange
            string inputNumbers = "1x2x5";
            int expectedResult = 8;
            int[] expectedParsedResult = [1, 2, 5];
            _mockParser.Setup(s => s.Parse(inputNumbers)).Returns(expectedParsedResult);

            // Act
            int result = _calculator.Add(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}