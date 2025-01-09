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

    }
}
