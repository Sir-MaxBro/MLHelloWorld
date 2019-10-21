using System.Collections.Generic;
using Microsoft.ML;
using Microsoft.ML.Data;
using ML.UI.EntireSquareRootML.Models;
using ML.UI.Generic.Constants;
using ML.UI.Generic.MLModels;

namespace ML.UI.EntireSquareRootML
{
    public class EntireSquareRootMl :  IBaseMlModel<EntireSquareRootFeature, EntireSquareRootPrediction, BinaryClassificationMetrics>
    {
        private readonly MLContext _mlContext = new MLContext();
        
        private ITransformer _trainedModel;
        private PredictionEngine<EntireSquareRootFeature, EntireSquareRootPrediction> _predictionFunction;

        public void InitializeMlModel(IEnumerable<EntireSquareRootFeature> trainingFeatures)
        {
            // load training data
            var trainingDataView = _mlContext.Data.LoadFromEnumerable(trainingFeatures);

            // build pipeline
            var pipeline = _mlContext.Transforms.Text
                .FeaturizeText(MlConstants.FeatureColumnName, nameof(EntireSquareRootFeature.Number))
                .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                    labelColumnName: nameof(EntireSquareRootFeature.IsEntireSquareRoot)));

            // build model
            _trainedModel = pipeline.Fit(trainingDataView);
            _predictionFunction =
                _mlContext.Model.CreatePredictionEngine<EntireSquareRootFeature, EntireSquareRootPrediction>(_trainedModel);
        }

        public BinaryClassificationMetrics Evaluate(IEnumerable<EntireSquareRootFeature> testFeatures)
        {
            var testDataView = _mlContext.Data.LoadFromEnumerable(testFeatures);
            return _mlContext.BinaryClassification.Evaluate(_trainedModel.Transform(testDataView),
                nameof(EntireSquareRootFeature.IsEntireSquareRoot));
        }

        public EntireSquareRootPrediction Predict(EntireSquareRootFeature feature)
        {
            return _predictionFunction.Predict(feature);
        }
    }
}