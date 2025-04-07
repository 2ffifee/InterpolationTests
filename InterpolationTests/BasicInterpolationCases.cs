using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpolationTests
{
    public static class BasicInterpolationCases
    {
        public static string SimpleMultiline()
        {
            int value = 42;
            return $"The answer is: {value
                .ToString()
                .ToUpper()}";
        }

        public static string ComplexExpression()
        {
            var items = new[] { 1, 2, 3 };
            return $"Total: {items
                .Where(x => x > 1)
                .Select(x => x * 2)
                .Sum()}";
        }

        public static string MethodChaining()
        {
            var text = " hello world ";
            return $"Processed: {text
                .Trim()
                .ToUpper()
                .Replace("WORLD", "C#")}";
        }

        public static string LambdaExpression()
        {
            Func<int, int> square = x => x * x;
            return $"Square of 5: {square
                .Invoke(5)}";
        }

        public static string TernaryOperator()
        {
            var random = new Random().Next(100);
            return $"The number is {(random > 50
                ? "greater than 50"
                : "50 or less")}";
        }

        public static string SwitchExpression()
        {
            object obj = 3.14;
            return $"Type is: {obj switch
            {
                int i => $"integer {i}",
                double d => $"double {d}",
                _ => "unknown"
            }}";
        }
    }
}
