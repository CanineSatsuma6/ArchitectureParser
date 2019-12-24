using System.Text;

namespace ArchitectureParser.Generators.Expressions
{
    public class InterfaceExpression : Expression
    {
        public string AccessLevel { get; }
        public string Name { get; }
        public string[] ImplementedInterfaces { get; }
        public ExpressionBlock Content { get; }

        public InterfaceExpression(string accessLevel, string name, string[] implementedInterfaces, ExpressionBlock content) : base()
        {
            AccessLevel = accessLevel;
            Name = name;
            ImplementedInterfaces = implementedInterfaces;
            Content = content;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine((AccessLevel == null ? string.Empty : AccessLevel + " ") + "interface " + Name + (ImplementedInterfaces == null || ImplementedInterfaces.Length < 1 ? string.Empty : " implements " + string.Join(", ", ImplementedInterfaces)))
                   .Append(Content.Indent());

            return builder.ToString();
        }
    }
}
