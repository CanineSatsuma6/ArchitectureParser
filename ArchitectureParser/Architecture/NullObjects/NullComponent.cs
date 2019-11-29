using System.Collections.Generic;

using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.NullObjects
{
    public class NullComponent : Connectable
    {
        private NullSet<IConnection> m_connections;

        public override ISet<IConnection> Connections
        {
            get { return m_connections; }
        }

        public NullComponent() : base("")
        {
            m_connections = new NullSet<IConnection>();
        }
    }
}
