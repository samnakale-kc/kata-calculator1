using Moq;
using StringCalculator1;
using StringCalculator1.Services.DelimeterService;
using StringCalculator1.Services.StringParser;

namespace StringCalculator1Tests.Services
{
    public class StringParserTests
    {
        private readonly IStringParser _parser;

        private readonly Mock<IDelimeterService> _delimeterServiceMock;

        public StringParserTests()
        {
            _delimeterServiceMock = new Mock<IDelimeterService>();
            _parser = new StringParser(_delimeterServiceMock.Object);

        }

        [Fact]
        public void GivenEmptyStringInput_WhenParseCalled_ThenReturnEmptyArray()
        {
            // Arrange
            string inputNumbers = "";
            int[] expectedResult = [];

            // Act
            int[] result = _parser.Parse(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCommaDelimetedInput_WhenParseCalled_ThenReturnNumbers()
        {
            // Arrange
            string inputNumbers = "1,2";
            int[] expectedResult = [1, 2];
            string[] expectedNumbersFromDelimeterService = ["1", "2"];
            _delimeterServiceMock.Setup(s => s.GetNumbersFromDelimetedString(inputNumbers)).Returns(expectedNumbersFromDelimeterService);

            // Act
            int[] result = _parser.Parse(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomDelimetedInput_WhenParseCalled_ThenReturnNumbers()
        {
            // Arrange
            string inputNumbers = "//;\n1;2";
            int[] expectedResult = [1, 2];
            string[] expectedNumbersFromDelimeterService = ["1", "2"];
            _delimeterServiceMock.Setup(s => s.GetNumbersFromDelimetedString(inputNumbers)).Returns(expectedNumbersFromDelimeterService);

            // Act
            int[] result = _parser.Parse(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomDelimetedInputWithoutFirstLine_WhenAddCalled_ThenReturnSum()
        {
            // Arrange
            string inputNumbers = "1;2;5";
            int[] expectedResult = [1, 2, 5];
            string[] expectedNumbersFromDelimeterService = ["1", "2", "5"];
            _delimeterServiceMock.Setup(s => s.GetNumbersFromDelimetedString(inputNumbers)).Returns(expectedNumbersFromDelimeterService);

            // Act
            int[] result = _parser.Parse(inputNumbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }



        [Fact]
        public void GivenInputWithANegetiveNumber_WhenAddCalled_ThenThrowAnException()
        {
            // Arrange
            string inputNumbers = "1;-2;5";
            string[] expectedNumbersFromDelimeterService = ["1", "-2", "5"];
            _delimeterServiceMock.Setup(s => s.GetNumbersFromDelimetedString(inputNumbers)).Returns(expectedNumbersFromDelimeterService);

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => _parser.Parse(inputNumbers));
            Assert.Equal("negatives not allowed -2", ex.Message);
        }

        [Fact]
        public void GivenInputWithNegetiveNumbers_WhenAddCalled_ThenThrowAnException()
        {
            // Arrange
            string inputNumbers = "1;-2;-5";
            string[] expectedNumbersFromDelimeterService = ["1", "-2", "-5"];
            _delimeterServiceMock.Setup(s => s.GetNumbersFromDelimetedString(inputNumbers)).Returns(expectedNumbersFromDelimeterService);

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => _parser.Parse(inputNumbers));
            Assert.Equal("negatives not allowed -2,-5", ex.Message);
        }
    }
}
