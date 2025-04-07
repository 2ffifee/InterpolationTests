using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpolationTests
{
    public static class EdgeCases
    {
        /*
        public static string EmptyInterpolation()
        {
            return $"Empty { } interpolation";
        }
        
        public static string WhitespaceOnly()
        {
            return $"Whitespace {
    
            } interpolation";
        }
        */
        
        public static string NestedInterpolation()
        {
            var inner = "nested";
            return $"Outer: {$"Inner: {inner}"}";
        }

        public static string StringLiteralWithNewlines()
        {
            return $"Contains: {"multi\nline\nstring"}";
        }

        public static string InterpolationWithComments()
        {
            return $"Value: { /* start */
                GetRandomNumber()
                    // middle comment
                    .ToString()
                /* end */ }";

            static int GetRandomNumber() => new Random().Next(100);
        }
    }
}
