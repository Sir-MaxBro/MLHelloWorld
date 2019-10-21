using System;
using ML.UI.EvenNumberML;
using ML.UI.EvenNumberML.Models;
using ML.UI.EvenNumberML.Providers;
using Const = ML.UI.EvenNumberML.Constants.NumberFeatureCountConstants;
using RootConst = ML.UI.EntireSquareRootML.Constants.EntireSquareRootFeatureCountConstants;

namespace ML.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var evenNumberMlModel = new EvenNumberMlModel();
            var numberFeatureProvider = new NumberFeatureProvider();
            evenNumberMlModel.InitializeMlModel(
                numberFeatureProvider.GetNumberFeatures(Const.TrainingDataStartNumber, Const.TrainingDataCount));
            var metrics =
                evenNumberMlModel.Evaluate(
                    numberFeatureProvider.GetNumberFeatures(Const.TestDataStartNumber, Const.TestDataCount));
            Console.WriteLine($"Accuracy: {metrics.Accuracy}");

            while (true)
            {
                var inputNumber = Console.ReadLine();
                if (int.TryParse(inputNumber, out var number))
                {
                    var prediction = evenNumberMlModel.Predict(new NumberFeature {Number = number.ToString()});
                    Console.WriteLine($"The number {number} is even = {prediction.IsEven}.");
                }
                else
                {
                    Console.WriteLine($"{inputNumber} is not a int number.");
                }
            }

/*          var entireSquareRootFeatureProvider = new EntireSquareRootFeatureProvider();
            var evenNumberMlModel = new EntireSquareRootMl();
            evenNumberMlModel.InitializeMlModel(
                entireSquareRootFeatureProvider.GetNumberFeatures(RootConst.TrainingDataStartNumber, RootConst.TrainingDataCount));
            var metrics =
                evenNumberMlModel.Evaluate(
                    entireSquareRootFeatureProvider.GetNumberFeatures(RootConst.TrainingDataStartNumber, RootConst.TrainingDataCount));
            Console.WriteLine($"Accuracy: {metrics.Accuracy}");

            while (true)
            {
                var inputNumber = Console.ReadLine();
                if (int.TryParse(inputNumber, out var number))
                {
                    var prediction = evenNumberMlModel.Predict(new EntireSquareRootFeature {Number = number.ToString()});
                    Console.WriteLine($"The number {number} is entire square root = {prediction.IsEntireSquareRoot}.");
                }
                else
                {
                    Console.WriteLine($"{inputNumber} is not a int number.");
                }
            }*/
        }
    }
}