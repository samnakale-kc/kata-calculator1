using StringCalculator1;

namespace StringCalculator1Tests
{
    public class StringCalculator1Tests
    {
        [Fact]
        public void GivenEmptyString_WhenAddCalled_ThenReturnZero()
        {
            // Arrange
            var calculator = new Calculator();
            string numbers = "";
            const int expectedResult = 0;

            // Act
            int result = calculator.Add(numbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void GivenOneOrTwoNumbers_WhenAddCalled_ThenReturnSum(string numbers, int expectedResult)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.Add(numbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}