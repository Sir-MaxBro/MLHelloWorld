using System;
using System.Collections.Generic;
using System.Linq;

namespace ML.UI.Generic.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> enumerable)
        {
            var randomGenerator = new Random();
            return enumerable.OrderBy(ei => randomGenerator.Next()).ToList();
        }
    }
}