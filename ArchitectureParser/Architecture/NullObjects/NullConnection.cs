using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.NullObjects
{
    public sealed class NullConnection : IConnection
    {
        private static NullConnection m_instance;
        public  static NullConnection Instance { get { return m_instance ?? (m_instance = new NullConnection()); } }

        public IConnectable Source
        {
            get { return NullComponent.Instance; }
        }

        public string SourceOutput
        {
            get { return string.Empty; }
            set { }
        }

        public IConnectable Destination
        {
            get { return NullComponent.Instance; }
        }

        public string DestinationInput
        {
            get { return string.Empty; }
            set { }
        }

        private NullConnection()
        {
            // Do nothing. Hide public default constructor
        }

        public void Connect()
        {
            return;
        }
    }
}
