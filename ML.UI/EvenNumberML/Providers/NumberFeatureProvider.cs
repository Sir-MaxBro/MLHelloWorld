using ML.UI.EvenNumberML.Models;
using ML.UI.Generic.Providers;

namespace ML.UI.EvenNumberML.Providers
{
    public class NumberFeatureProvider : BaseNumberFeatureProvider<NumberFeature>
    {
        protected  override NumberFeature BuildNumberFeature(int number)
        {
            return new NumberFeature {Number = number.ToString(), IsEven = (number % 2 == 0)};
        }
    }
}