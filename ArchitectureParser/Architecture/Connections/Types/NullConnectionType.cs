namespace ArchitectureParser.Architecture.Connections.Types
{
    public class NullConnectionType : IJavaType, ICPPType
    {
        public string Name
        {
            get { return string.Empty; }
        }

        public string DefaultValue
        {
            get { return string.Empty; }
        }
    }
}
