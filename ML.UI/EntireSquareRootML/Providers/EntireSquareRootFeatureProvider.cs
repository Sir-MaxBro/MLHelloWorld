using System;
using ML.UI.EntireSquareRootML.Models;
using ML.UI.Generic.Providers;

namespace ML.UI.EntireSquareRootML.Providers
{
    public class EntireSquareRootFeatureProvider : BaseNumberFeatureProvider<EntireSquareRootFeature>
    {
        protected override EntireSquareRootFeature BuildNumberFeature(int number)
        {
            if (Math.Abs(Math.Sqrt(number) % 1) <= (double.Epsilon * 100))
            {
                var a = 5;
            }
            
            return new EntireSquareRootFeature
            {
                Number = number.ToString(),
                IsEntireSquareRoot = (Math.Abs(Math.Sqrt(number) % 1) <= (double.Epsilon * 100)),
            };
        }
    }
}