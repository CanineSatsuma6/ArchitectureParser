using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchitectureParser.Generators.Expressions
{
    public class FunctionPrototypeExpression : Expression
    {
        public int    AccessLevelPad { get; set; }
        public int    ReturnTypePad  { get; set; }
        public string AccessLevel    { get; }
        public string ReturnType     { get; }
        public string Name           { get; }
        public IEnumerable<FunctionParameterExpression> Parameters { get; }

        public FunctionPrototypeExpression(string accessLevel, string returnType, string name, params FunctionParameterExpression[] parameters) : base()
        {
            AccessLevel = accessLevel;
            ReturnType = returnType;
            Name = name;
            Parameters = parameters;

            AccessLevelPad = AccessLevel?.Length ?? 0;
            ReturnTypePad  = ReturnType?.Length  ?? 0;
        }

        public override string ToString()
        {
            return (AccessLevel == null ? string.Empty : AccessLevel.PadRight(AccessLevelPad) + " ") + 
                   (ReturnType == null ? string.Empty : ReturnType.PadRight(ReturnTypePad) + " ") + 
                   Name + "(" + (Parameters == null ? string.Empty : string.Join(", ", Parameters.Select(p => p.ToString()))) + ");";
        }
    }
}
