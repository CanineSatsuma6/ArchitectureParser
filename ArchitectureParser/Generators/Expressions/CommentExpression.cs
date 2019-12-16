using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureParser.Expressions
{
    public class CommentExpression : Expression
    {
        public string[] CommentLines { get; }

        public CommentExpression(params string[] lines) : base()
        {
            CommentLines = lines;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (CommentLines != null)
            {
                if (CommentLines.Length > 2)
                {
                    builder.AppendLine("/*");

                    foreach (var line in CommentLines)
                    {
                        builder.AppendLine(Indent(" * " + line));
                    }

                    builder.Append(Indent(" */"));
                }

                else
                {
                    builder.Append("/* " + CommentLines[0] + " */");
                }
            }

            return builder.ToString();
        }
    }
}
