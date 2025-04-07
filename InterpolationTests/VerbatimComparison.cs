using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpolationTests
{
    public static class VerbatimComparison
    {
        public static string NonVerbatim()
        {
            return $"Non-verbatim: {GetValue(
                "param1",
                "param2")}";
        }

        public static string Verbatim()
        {
            return $@"Verbatim: {GetValue(
                "param1",
                "param2")}";
        }

        public static string GetValue(string a, string b) => a + b;
    }
}
