using FluentAssertions;
using StringCalculator1;

namespace StringCalculator1Tests
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_CanTakeUpTo2Numbers_ExpectSum()
        {
            // Arrange
            string numbers = "1,2";
            var calculator = new Calculator();

            // Act 
            int result = calculator.Add(numbers);

            // Assert
            result.Should().Be(3);

        }

        [Test]
        public void Add_SingleNumber_ExpectSum()
        {
            // Arrange
            string numbers = "1";
            var calculator = new Calculator();

            // Act 
            int result = calculator.Add(numbers);

            // Assert
            result.Should().Be(1);

        }

        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            // Arrange
            string numbers = "";
            var calculator = new Calculator();

            // Act 
            int result = calculator.Add(numbers);

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void Add_WithNewLineInString_ExpectSum()
        {
            // Arrange
            string numbers = "1\n2,3";
            var calculator = new Calculator();

            // Act 
            int result = calculator.Add(numbers);

            // Assert
            result.Should().Be(6);

        }

        [Test]
        public void Add_WithDifferentDelimeterString_ExpectSum()
        {
            // Arrange
            string numbers = "//;\n1;2";
            var calculator = new Calculator();

            // Act 
            int result = calculator.Add(numbers);

            // Assert
            result.Should().Be(3);

        }

        [Test]
        public void Add_WithDifferentDelimeterStringWithoutTheFirstLineShowingDelimeter_ExpectSum()
        {
            // Arrange
            string numbers = "1;2";
            var calculator = new Calculator();

            // Act 
            int result = calculator.Add(numbers);

            // Assert
            result.Should().Be(3);

        }

        [Test]
        public void Add_WithNegetiveNumber_ThrowsError()
        {

            // Arrange
            var calculator = new Calculator();
            var exceptionMessage = "";

            // Act
            try
            {
                int result = calculator.Add("-1, 2");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            // Assert
            exceptionMessage.Should().Be("negatives not allowed -1");
        }


        [Test]
        public void Add_WithNegetiveNumbers_ThrowsError()
        {
            // Arrange
            var calculator = new Calculator();
            var exceptionMessage = "";

            // Act
            try
            {
                int result = calculator.Add("-1, -2");
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }

            // Assert
            exceptionMessage.Should().Be("negatives not allowed -1,-2");
        }

        [Test]
        public void Add_NumbersBiggerThanOneThousand_ShouldBeIgnored()
        {
            // Arrange
            string numbers = "2,1001";
            var calculator = new Calculator();

            // Act 
            int result = calculator.Add(numbers);

            // Assert
            result.Should().Be(2);

        }

    }
}
