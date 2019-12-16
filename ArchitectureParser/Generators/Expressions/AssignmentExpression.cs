namespace ArchitectureParser.Expressions
{
    public class AssignmentExpression : Expression
    {
        public string LValue { get; }
        public string RValue { get; }
        public int    NamePad { get; set; }

        public AssignmentExpression(string lVal, string rVal) : base()
        {
            LValue = lVal;
            RValue = rVal;

            NamePad = lVal?.Length ?? 0;
        }

        public override string ToString()
        {
            return LValue.PadRight(NamePad) + " = " + RValue + ";";
        }
    }
}
