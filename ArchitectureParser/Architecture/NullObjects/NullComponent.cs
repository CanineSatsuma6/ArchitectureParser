using System.Collections.Generic;

using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.NullObjects
{
    public class NullComponent : Connectable
    {
        private NullSet<Connection> m_connections;

        public override ISet<Connection> Connections
        {
            get { return m_connections; }
        }

        public NullComponent() : base("")
        {
            // Do nothing
        }
    }
}
