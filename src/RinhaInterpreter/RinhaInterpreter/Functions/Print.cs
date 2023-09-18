using RinhaInterpreter.Models;

namespace RinhaInterpreter.Functions
{
    public class Print : Term
    {
        public Term Value { get; set; }

        public string PrintExecute()
        {
            return Value.ToString();
        }

    }
}
