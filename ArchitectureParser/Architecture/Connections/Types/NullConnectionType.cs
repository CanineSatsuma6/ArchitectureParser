namespace ArchitectureParser.Architecture.Connections.Types
{
    public sealed class NullConnectionType : IConnectionType
    {
        private static NullConnectionType instance;
        public  static NullConnectionType Instance { get { return instance ?? (instance = new NullConnectionType()); } }

        private NullConnectionType()
        {
            // Do nothing. Hide public default constructor
        }

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
