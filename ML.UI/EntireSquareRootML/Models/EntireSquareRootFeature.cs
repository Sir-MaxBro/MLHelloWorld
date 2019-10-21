namespace ML.UI.EntireSquareRootML.Models
{
    public class EntireSquareRootFeature
    {
        public bool IsEntireSquareRoot { get; set; }
        public string Number { get; set; }
        
        public override int GetHashCode() => 289 ^ this.Number.GetHashCode();
    }
}