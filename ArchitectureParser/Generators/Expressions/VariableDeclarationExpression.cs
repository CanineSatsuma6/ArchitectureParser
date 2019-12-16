namespace ArchitectureParser.Expressions
{
    public class VariableDeclarationExpression : Expression
    {
        public int    AccessLevelPad { get; set; }
        public int    TypePad        { get; set; }
        public int    NamePad        { get; set; }
        public string AccessLevel    { get; }
        public string Type           { get; }
        public string Name           { get; }
        public string DefaultValue   { get; }

        public VariableDeclarationExpression(string accessLevel, string type, string name, string defaultValue = null) : base()
        {
            AccessLevel  = accessLevel;
            Type         = type;
            Name         = name;
            DefaultValue = defaultValue;

            AccessLevelPad = AccessLevel?.Length ?? 0;
            TypePad        = Type?.Length        ?? 0;
            NamePad        = Name?.Length        ?? 0;
        }

        public override string ToString()
        {
            return (AccessLevel == null ? string.Empty : AccessLevel.PadRight(AccessLevelPad) + " ") + Type.PadRight(TypePad) + " " + Name.PadRight(DefaultValue == null ? 0 : NamePad) + (DefaultValue == null ? string.Empty : " = " + DefaultValue) + ";";
        }
    }
}
