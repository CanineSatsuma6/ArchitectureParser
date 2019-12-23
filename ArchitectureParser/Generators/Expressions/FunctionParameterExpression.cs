namespace ArchitectureParser.Generators.Expressions
{
    public class FunctionParameterExpression : Expression
    {
        public string Type { get; }
        public string Name { get; }

        public FunctionParameterExpression(string type, string name) : base()
        {
            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            return Type + " " + Name;
        }
    }
}
