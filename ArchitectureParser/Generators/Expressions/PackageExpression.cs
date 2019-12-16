namespace ArchitectureParser.Expressions
{
    public class PackageExpression : Expression
    {
        public string PackageName { get; }

        public PackageExpression(string packageName) : base()
        {
            PackageName = packageName;
        }

        public override string ToString()
        {
            return "package " + PackageName + ";";
        }
    }
}
