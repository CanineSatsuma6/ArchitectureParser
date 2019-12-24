namespace ArchitectureParser.Generators.Expressions
{
    public class NewlineExpression : Expression
    {
        private static NewlineExpression instance = new NewlineExpression();

        public static NewlineExpression Get() => instance;

        public NewlineExpression() : base() { }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
