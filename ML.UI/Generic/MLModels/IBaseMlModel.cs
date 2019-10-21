using System.Collections.Generic;

namespace ML.UI.Generic.MLModels
{
    public interface IBaseMlModel<in TFeature, out TPredict, out TMetrics>
    {
        void InitializeMlModel(IEnumerable<TFeature> trainingFeatures);

        TMetrics Evaluate(IEnumerable<TFeature> testFeatures);

        TPredict Predict(TFeature feature);
    }
}