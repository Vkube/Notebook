namespace Notebook
{
    public class Validation
    {
        public bool Required { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public char[] ValidSymbols { get; set; }



        public Validation(bool isRequare, int minValue, int maxValue, char[] symbols)
        {
            Required = isRequare;
            MinLength = minValue;
            MaxLength = maxValue;
            ValidSymbols = symbols;
        }
    }
}