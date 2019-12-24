using System.Linq;

namespace ArchitectureParser.Generators.Expressions
{
    public abstract class Expression
    {
        public static string Tab = "    ";

        public int IndentLevel { get; set; }

        public Expression()
        {
            IndentLevel = 0;
        }

        public abstract new string ToString();

        public string Indent(string str = null)
        {
            return string.Join(string.Empty, Enumerable.Repeat(Tab, IndentLevel)) + (str ?? ToString());
        }
    }
}
