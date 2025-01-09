using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using StringCalculator1;

namespace StringCalculator1Tests
{
    public class InputStringParserTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Clean_UntrimedString_ExpecCleanString()
        {
            // Arrange
            string input = "    1,2       ";
            var parser = new InputStringParser();

            // Act 
            string result = parser.Clean(input);

            // Assert
            result.Should().Be("1,2");

        }

        [Test]
        public void Clean_StringWithDifferentDelimeter_ExpecCleanString()
        {
            // Arrange
            string input = "1;2;3";
            var parser = new InputStringParser();

            // Act 
            string result = parser.Clean(input);

            // Assert
            result.Should().Be("1,2,3");

        }

        [Test]
        public void Clean_StringWithDifferentDelimeterOnFirstLine_ExpecCleanString()
        {
            // Arrange
            string input = "//;\n1;2;3";
            var parser = new InputStringParser();

            // Act 
            string result = parser.Clean(input);

            // Assert
            result.Should().Be("1,2,3");

        }

        [Test]
        public void ConvertCleanInputToArray_StringWithDifferentDelimeterOnFirstLine_ExpecCleanString()
        {
            // Arrange
            string input = "1,2,3";
            var parser = new InputStringParser();

            // Act 
            int[] result = parser.ConvertCleanInputToArray(input).ToArray();

            // Assert
            int[] expectedResult = [1, 2, 3];
            result.Should().ContainInOrder(expectedResult);

        }
    }
}
