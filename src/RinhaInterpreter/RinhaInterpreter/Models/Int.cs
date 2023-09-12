namespace RinhaCompiler.Models
{
    public class Int : Term
    {
        public int Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
