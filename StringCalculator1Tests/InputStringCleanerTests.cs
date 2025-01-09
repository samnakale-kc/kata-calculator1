using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using StringCalculator1;

namespace StringCalculator1Tests
{
    public class InputStringCleanerTests
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
            var cleaner = new InputStringCleaner();

            // Act 
            string result = cleaner.Clean(input);

            // Assert
            result.Should().Be("1,2");

        }

        [Test]
        public void Clean_StringWithDifferentDelimeter_ExpecCleanString()
        {
            // Arrange
            string input = "1;2;3";
            var cleaner = new InputStringCleaner();

            // Act 
            string result = cleaner.Clean(input);

            // Assert
            result.Should().Be("1,2,3");

        }

        [Test]
        public void Clean_StringWithDifferentDelimeterOnFirstLine_ExpecCleanString()
        {
            // Arrange
            string input = "//;\n1;2;3";
            var cleaner = new InputStringCleaner();

            // Act 
            string result = cleaner.Clean(input);

            // Assert
            result.Should().Be("1,2,3");

        }
    }
}
