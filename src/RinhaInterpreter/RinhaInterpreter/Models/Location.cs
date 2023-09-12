namespace RinhaCompiler.Models
{
    public class Location
    {
        public int Start { get; set; }
        public int End { get; set; }
        public string FileName { get; set; }

        public Location(dynamic node)
        {
            Start = node.start;
            End = node.end;
            FileName = node.filename;
        }
    }
}
