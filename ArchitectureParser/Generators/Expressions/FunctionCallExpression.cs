namespace ArchitectureParser.Generators.Expressions
{
    public class FunctionCallExpression : Expression
    {
        public string Name { get; }
        public string[] Parameters { get; }

        public FunctionCallExpression(string name, params string[] parameters) : base()
        {
            Name = name;
            Parameters = parameters;
        }

        public override string ToString()
        {
            return Name + "(" + (Parameters == null || Parameters.Length < 1 ? string.Empty : string.Join(", ", Parameters)) + ");";
        }
    }
}
