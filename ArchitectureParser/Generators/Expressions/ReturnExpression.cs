namespace ArchitectureParser.Generators.Expressions
{
    public class ReturnExpression : Expression
    {
        public string Value { get; }

        public ReturnExpression(string value) : base()
        {
            Value = value;
        }

        public override string ToString()
        {
            return "return " + Value + ";";
        }
    }
}
