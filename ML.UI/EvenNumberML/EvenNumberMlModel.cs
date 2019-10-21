using System.Collections.Generic;
using Microsoft.ML;
using Microsoft.ML.Data;
using ML.UI.EvenNumberML.Models;
using ML.UI.Generic.Constants;
using ML.UI.Generic.MLModels;

namespace ML.UI.EvenNumberML
{
    public class EvenNumberMlModel : IBaseMlModel<NumberFeature, NumberPrediction, BinaryClassificationMetrics>
    {
        private readonly MLContext _mlContext = new MLContext();

        private ITransformer _trainedModel;
        private PredictionEngine<NumberFeature, NumberPrediction> _predictionFunction;

        public void InitializeMlModel(IEnumerable<NumberFeature> trainingNumberFeatures)
        {
            // load training data
            var trainingDataView = _mlContext.Data.LoadFromEnumerable(trainingNumberFeatures);

            // build pipeline
            var pipeline = _mlContext.Transforms.Text
                .FeaturizeText(MlConstants.FeatureColumnName, nameof(NumberFeature.Number))
                .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                    labelColumnName: nameof(NumberFeature.IsEven)));

            // build model
            _trainedModel = pipeline.Fit(trainingDataView);
            _predictionFunction =
                _mlContext.Model.CreatePredictionEngine<NumberFeature, NumberPrediction>(_trainedModel);
        }

        public BinaryClassificationMetrics Evaluate(IEnumerable<NumberFeature> testNumberFeatures)
        {
            var testDataView = _mlContext.Data.LoadFromEnumerable(testNumberFeatures);
            return _mlContext.BinaryClassification.Evaluate(_trainedModel.Transform(testDataView),
                nameof(NumberFeature.IsEven));
        }

        public NumberPrediction Predict(NumberFeature numberFeature)
        {
            return _predictionFunction.Predict(numberFeature);
        }
    }
}