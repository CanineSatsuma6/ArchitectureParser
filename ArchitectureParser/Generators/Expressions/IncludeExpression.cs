namespace ArchitectureParser.Expressions
{
    public class IncludeExpression : Expression
    {
        public string Include { get; }

        public IncludeExpression(string include) : base()
        {
            Include = include;
        }

        public override string ToString()
        {
            return "#include \"" + Include + "\"";
        }
    }
}
