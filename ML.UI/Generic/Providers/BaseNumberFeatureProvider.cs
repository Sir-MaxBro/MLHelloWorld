using System.Collections.Generic;
using System.Linq;
using ML.UI.Generic.Extensions;

namespace ML.UI.Generic.Providers
{
    public abstract class BaseNumberFeatureProvider<TFeature>
    {
        public IEnumerable<TFeature> GetNumberFeatures(int startNumber, int count)
        {
            var generatedNumbers = new HashSet<TFeature>();
            for (var number = startNumber; number < (startNumber + count); number++)
            {
                generatedNumbers.Add(this.BuildNumberFeature(number));
            }

            return generatedNumbers.Randomize().ToList();
        }

        protected abstract TFeature BuildNumberFeature(int number);
    }
}