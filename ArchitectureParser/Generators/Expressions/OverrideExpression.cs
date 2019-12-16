namespace ArchitectureParser.Expressions
{
    public class OverrideExpression : Expression
    {
        private static OverrideExpression instance = new OverrideExpression();
        public static OverrideExpression Get() => instance;

        public OverrideExpression() : base() { }

        public override string ToString()
        {
            return "@Override";
        }
    }
}
