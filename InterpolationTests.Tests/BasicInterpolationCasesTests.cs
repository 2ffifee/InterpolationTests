using Xunit;
using System;
using System.Linq;

namespace InterpolationTests.Tests
{
    public class BasicInterpolationTests
    {
        [Fact]
        public void SimpleMultiline_ReturnsCorrectUppercaseString()
        {
            // Act
            var result = BasicInterpolationCases.SimpleMultiline();

            // Assert
            Assert.Equal("The answer is: 42", result);
            Assert.DoesNotContain("\n", result); // Verify no actual newlines in output
            Assert.DoesNotContain("\r", result);
        }

        [Fact]
        public void ComplexExpression_FiltersAndCalculatesCorrectSum()
        {
            // Arrange
            var expectedSum = new[] { 1, 2, 3 }
                .Where(x => x > 1)
                .Select(x => x * 2)
                .Sum();

            // Act
            var result = BasicInterpolationCases.ComplexExpression();

            // Assert
            Assert.Equal($"Total: {expectedSum}", result);
            Assert.Matches(@"^Total: \d+$", result); // Verify format
        }

        [Fact]
        public void MethodChaining_ExecutesAllOperationsInOrder()
        {
            // Act
            var result = BasicInterpolationCases.MethodChaining();

            // Assert
            Assert.Equal("Processed: HELLO C#", result);

        }

        [Fact]
        public void LambdaExpression_ComputesSquareCorrectly()
        {
            // Act
            var result = BasicInterpolationCases.LambdaExpression();

            // Assert
            Assert.Equal("Square of 5: 25", result);

            // Verify lambda actually works:
            var value = int.Parse(result.Split(':')[1].Trim());
            Assert.Equal(25, value);
        }

        [Fact]
        public void TernaryOperator_CoversBothBranches()
        {
            // This test runs multiple times to ensure we hit both branches
            bool greaterThan50Found = false;
            bool lessOrEqual50Found = false;

            for (int i = 0; i < 100; i++)
            {
                var result = BasicInterpolationCases.TernaryOperator();

                if (result.Contains("greater than 50"))
                {
                    greaterThan50Found = true;
                    Assert.StartsWith("The number is greater than 50", result);
                }
                else
                {
                    lessOrEqual50Found = true;
                    Assert.StartsWith("The number is 50 or less", result);
                }

                if (greaterThan50Found && lessOrEqual50Found)
                    break;
            }

            Assert.True(greaterThan50Found, "Should hit >50 branch");
            Assert.True(lessOrEqual50Found, "Should hit <=50 branch");
        }

        [Fact]
        public void SwitchExpression_MatchesDoubleCase()
        {
            // Act
            var result = BasicInterpolationCases.SwitchExpression();

            // Assert
            Assert.StartsWith("Type is: double 3,14", result);

            // Verify the pattern matching:
            var numericPart = result.Split(' ').Last();
            Assert.True(double.TryParse(numericPart, out _));
        }

        [Fact]
        public void AllMethods_ReturnNonEmptyStrings()
        {
            // Verify no method returns null or empty string
            Assert.False(string.IsNullOrEmpty(BasicInterpolationCases.SimpleMultiline()));
            Assert.False(string.IsNullOrEmpty(BasicInterpolationCases.ComplexExpression()));
            Assert.False(string.IsNullOrEmpty(BasicInterpolationCases.MethodChaining()));
            Assert.False(string.IsNullOrEmpty(BasicInterpolationCases.LambdaExpression()));
            Assert.False(string.IsNullOrEmpty(BasicInterpolationCases.TernaryOperator()));
            Assert.False(string.IsNullOrEmpty(BasicInterpolationCases.SwitchExpression()));
        }
    }
}