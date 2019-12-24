using System.Collections.Generic;
using System.Text;

namespace ArchitectureParser.Generators.Expressions
{
    public class ExpressionBlock : Expression
    {
        public List<Expression> Expressions { get; }

        public ExpressionBlock(params Expression[] expressions) : base()
        {
            Expressions = new List<Expression>();
            Expressions.AddRange(expressions);
        }

        public void AddExpression(Expression expression)
        {
            Expressions.Add(expression);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("{");

            foreach (var expression in Expressions)
            {
                expression.IndentLevel = IndentLevel + 1;
                builder.AppendLine(expression.Indent());
            }

            return builder.Append(Indent("}")).ToString();
        }
    }
}
