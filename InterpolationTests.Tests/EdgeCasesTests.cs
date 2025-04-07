using Xunit;
using System;
using System.Linq;

namespace InterpolationTests.Tests
{
    public class EdgeCasesTests
    {
        [Fact]
        public void NestedInterpolation_ProducesCorrectOutput()
        {
            // Act
            var result = EdgeCases.NestedInterpolation();

            // Assert
            Assert.Equal("Outer: Inner: nested", result);
            Assert.DoesNotContain("\n", result);
            Assert.DoesNotContain("\r", result);
        }

        [Fact]
        public void StringLiteralWithNewlines_PreservesEscapedNewlines()
        {
            // Act
            var result = EdgeCases.StringLiteralWithNewlines();

            // Assert
            Assert.Equal("Contains: multi\nline\nstring", result);

            // Verify exact newline count
            var newlineCount = result.Count(c => c == '\n');
            Assert.Equal(2, newlineCount);
        }

        [Fact]
        public void InterpolationWithComments_IgnoresCommentsAndReturnsValidNumber()
        {
            // Act
            var result = EdgeCases.InterpolationWithComments();

            // Assert
            Assert.Matches(@"^Value: \d{1,3}$", result); // 0-99

            // Verify it's a parseable number
            var numericPart = result.Split(':')[1].Trim();
            Assert.True(int.TryParse(numericPart, out int number));
            Assert.InRange(number, 0, 99);
        }

    }
}