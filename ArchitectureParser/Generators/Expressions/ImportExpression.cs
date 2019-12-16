namespace ArchitectureParser.Expressions
{
    public class ImportExpression : Expression
    {
        public string Import { get; }

        public ImportExpression(string import) : base()
        {
            Import = import;
        }

        public override string ToString()
        {
            return "import " + Import + ";";
        }
    }
}
