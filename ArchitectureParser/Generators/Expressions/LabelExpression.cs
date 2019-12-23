using System.Text;

namespace ArchitectureParser.Generators.Expressions
{
    public class LabelExpression : Expression
    {
        public string Label { get; }

        public LabelExpression(string label) : base()
        {
            Label = label;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("/**" + new string('*', Label.Length) + "**")
                   .AppendLine(Indent(" * " + Label.ToUpper() + " *"))
                   .Append(Indent(" **" + new string('*', Label.Length) + "**/"));

            return builder.ToString();
        }
    }
}
