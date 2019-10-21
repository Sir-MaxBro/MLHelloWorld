using Microsoft.ML.Data;

namespace ML.UI.EvenNumberML.Models
{
    public class NumberPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsEven { get; set; }
    }
}