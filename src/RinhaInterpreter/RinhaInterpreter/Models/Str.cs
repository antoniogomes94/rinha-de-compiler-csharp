namespace RinhaInterpreter.Models
{
    public class Str : Term
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
