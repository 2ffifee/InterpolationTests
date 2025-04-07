using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using System.Linq;

namespace InterpolationTests.Tests
{
    public class VerbatimComparisonTests
    {
        [Fact]
        public void NonVerbatim_HandlesMultilineInterpolation()
        {
            // Act
            var result = VerbatimComparison.NonVerbatim();

            // Assert
            Assert.Equal("Non-verbatim: param1param2", result);
            Assert.DoesNotContain("\n", result); // Newlines in expression shouldn't appear in output
            Assert.DoesNotContain("\r", result);
        }

        [Fact]
        public void Verbatim_HandlesMultilineInterpolation()
        {
            // Act
            var result = VerbatimComparison.Verbatim();

            // Assert
            Assert.Equal("Verbatim: param1param2", result);
            Assert.DoesNotContain("\n", result); // Verbatim affects text parts, not interpolations
            Assert.DoesNotContain("\r", result);
        }

        [Fact]
        public void BothMethods_ProduceSameResult()
        {
            // Act
            var nonVerbatim = VerbatimComparison.NonVerbatim();
            var verbatim = VerbatimComparison.Verbatim();

            // Assert
            Assert.Equal(
                nonVerbatim.Replace("Non-verbatim", ""),
                verbatim.Replace("Verbatim", ""));
        }

        [Fact]
        public void GetValue_ConcatenatesStringsCorrectly()
        {
            // Act
            var result = VerbatimComparison.GetValue("test", "123");

            // Assert
            Assert.Equal("test123", result);
            Assert.Equal(7, result.Length);
            Assert.DoesNotContain(" ", result);
        }


        [Fact]
        public void Verbatim_WithMultilineText_Works()
        {
            // This shows the real difference with verbatim strings
            var verbatimText = $@"Actual:
    Multiline {"text"}";

            Assert.Contains("\n", verbatimText); // Verbatim allows newlines in text parts
            Assert.Contains("    ", verbatimText); // Preserves indentation
        }
    }
}
