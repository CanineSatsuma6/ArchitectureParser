using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ArchitectureParser.Expressions
{
    public class FunctionImplementationExpression : Expression
    {
        public string                                   AccessLevel { get; }
        public string                                   ReturnType  { get; }
        public string                                   Name        { get; }
        public FunctionParameterExpression[]            Parameters  { get; }
        public ExpressionBlock                          Content     { get; }

        public FunctionImplementationExpression(string accessLevel, string returnType, string name, ExpressionBlock content, params FunctionParameterExpression[] parameters) : base()
        {
            AccessLevel = accessLevel;
            ReturnType = returnType;
            Name = name;
            Parameters = parameters;
            Content = content;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            Content.IndentLevel = IndentLevel;

            builder.AppendLine((AccessLevel == null ? string.Empty : AccessLevel + " ") + (ReturnType == null ? string.Empty : ReturnType + " ") + Name + "(" + (Parameters == null ? string.Empty : string.Join(", ", Parameters.Select(p => p.ToString()))) + ")")
                   .Append(Content.Indent());

            return builder.ToString();
        }
    }
}
