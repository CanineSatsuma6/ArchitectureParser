using System.Collections.Generic;

using ArchitectureParser.Architecture.Components;
using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.NullObjects
{
    public class NullComposition : CompositionBase
    {
        private NullSet<Connectable> m_contents;
        private NullSet<IConnection> m_connections;

        public override ISet<Connectable> Contents
        {
            get { return m_contents; }
        }

        public override ISet<IConnection> Connections
        {
            get { return m_connections; }
        }

        public NullComposition() : base(string.Empty)
        {
            m_contents = new NullSet<Connectable>();
        }

        public override void ConsolidateConnections()
        {
            return;
        }
    }
}
