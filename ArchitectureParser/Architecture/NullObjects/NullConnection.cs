using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.NullObjects
{
    public class NullConnection : IConnection
    {
        private Connectable m_source;
        private Connectable m_destination;

        public Connectable Source
        {
            get { return m_source; }
            set { }
        }

        public string SourceOutput
        {
            get { return string.Empty; }
            set { }
        }

        public Connectable Destination
        {
            get { return m_destination; }
            set { }
        }

        public string DestinationInput
        {
            get { return string.Empty; }
            set { }
        }

        public NullConnection()
        {
            m_source      = new NullComponent();
            m_destination = new NullComponent();
        }
    }
}
