using Microsoft.ML.Data;

namespace ML.UI.EntireSquareRootML.Models
{
    public class EntireSquareRootPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsEntireSquareRoot { get; set; }
    }
}