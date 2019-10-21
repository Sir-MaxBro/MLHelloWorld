namespace ML.UI.EvenNumberML.Models
{
    public class NumberFeature
    {
        public bool IsEven { get; set; }
        public string Number { get; set; }

        public override int GetHashCode() => 289 ^ this.Number.GetHashCode();
    }
}