using System.Text;
using System.Linq;

namespace ArchitectureParser.Generators.Expressions
{
    public abstract class ClassExpression : Expression
    {
        public string AccessLevel { get; }
        public string Modifier { get; }
        public string Name { get; }
        public string ExtendedClass { get; }
        public string[] ImplementedClasses { get; }
        public ExpressionBlock Content { get; }

        public ClassExpression(string accessLevel, string name, ExpressionBlock content, string modifier = null, string extendedClass = null, string[] implementedClasses = null) : base()
        {
            AccessLevel = accessLevel;
            Modifier = modifier;
            Name = name;
            ExtendedClass = extendedClass;
            ImplementedClasses = implementedClasses;
            Content = content;
        }

        public abstract override string ToString();
    }

    public class CPPClassExpression : ClassExpression
    {
        public CPPClassExpression(string accessLevel,
                                  string name,
                                  ExpressionBlock content,
                                  string modifier = null,
                                  string extendedClass = null,
                                  string[] implementedClasses = null)
            : base(accessLevel, name, content, modifier, extendedClass, implementedClasses) { }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            Content.IndentLevel = IndentLevel;

            builder.AppendLine("class " + Name + (ExtendedClass == null && (ImplementedClasses == null || ImplementedClasses.Length < 1) ? string.Empty : " : " + string.Join(", ", Enumerable.Concat(new string[] { ExtendedClass }, ImplementedClasses).Select(c => "public " + c))))
                   .Append(Content.Indent());

            return builder.ToString();
        }
    }

    public class JavaClassExpression : ClassExpression
    {
        public JavaClassExpression(string accessLevel,
                                   string name,
                                   ExpressionBlock content,
                                   string modifier = null,
                                   string extendedClass = null,
                                   string[] implementedClasses = null)
            : base(accessLevel, name, content, modifier, extendedClass, implementedClasses) { }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            Content.IndentLevel = IndentLevel;

            builder.AppendLine((AccessLevel == null ? string.Empty : AccessLevel + " ") +
                               (Modifier == null ? string.Empty : Modifier + " ") +
                               "class " + Name +
                               (ExtendedClass == null ? string.Empty : " extends " + ExtendedClass) +
                               (ImplementedClasses == null || ImplementedClasses.Length < 1 ? string.Empty : " implements " + string.Join(", ", ImplementedClasses)))
                   .Append(Content.Indent());

            return builder.ToString();
        }
    }
}