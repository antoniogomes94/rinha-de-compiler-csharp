namespace RinhaCompiler.Models
{
    public class Bool : Term
    {
        public bool Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
