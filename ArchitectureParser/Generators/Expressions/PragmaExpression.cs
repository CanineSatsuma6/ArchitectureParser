namespace ArchitectureParser.Expressions
{
    public class PragmaExpression : Expression
    {
        public string Pragma { get; }

        public PragmaExpression(string pragma) : base()
        {
            Pragma = pragma;
        }

        public override string ToString()
        {
            return "#pragma " + Pragma;
        }
    }
}
