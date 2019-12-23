using System.Text;

namespace ArchitectureParser.Generators.Expressions
{
    public class ForLoopExpression : Expression
    {
        public string          Initializer    { get; }
        public string          LoopCondition  { get; }
        public string          PostProcessing { get; }
        public ExpressionBlock Content        { get; }

        public ForLoopExpression(string initializer, string loopCondition, string postProcessing, ExpressionBlock content) : base()
        {
            Initializer    = initializer;
            LoopCondition  = loopCondition;
            PostProcessing = postProcessing;
            Content        = content;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            Content.IndentLevel = IndentLevel;

            builder.AppendLine("for (" + Initializer + "; " + LoopCondition + "; " + PostProcessing + ")");
            builder.Append(Content.Indent());

            return builder.ToString();
        }
    }
}
