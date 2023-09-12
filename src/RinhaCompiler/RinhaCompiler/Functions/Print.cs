using RinhaCompiler.Models;

namespace RinhaCompiler.Functions
{
    public class Print : Term
    {
        public Term Value { get; set; }

        public String PrintExecute()
        {
            return this.Value.ToString();
        }

    }
}
