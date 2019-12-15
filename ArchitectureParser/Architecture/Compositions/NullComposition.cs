using System.Collections.Generic;
using System.Drawing;

using ArchitectureParser.Architecture.Connections;
using ArchitectureParser.Architecture.Connections.Types;
using ArchitectureParser.Architecture.NullObjects;

namespace ArchitectureParser.Architecture.Compositions
{
    public sealed class NullComposition : IComposition
    {
        private static NullComposition m_instance;
        public  static NullComposition Instance { get { return m_instance ?? (m_instance = new NullComposition()); } }

        private NullSet<IConnectable> m_contents;
        private NullSet<IConnection>  m_connections;

        public string Name
        {
            get { return string.Empty; }
        }

        public ISet<IConnectable> Contents
        {
            get { return m_contents; }
        }

        public ISet<IConnection> Connections
        {
            get { return m_connections; }
        }

        public NullComposition()
        {
            m_contents    = new NullSet<IConnectable>();
            m_connections = new NullSet<IConnection>();
        }

        public IConnection Connect(IConnectable destination, string outputName, string inputName, Color type)
        {
            return NullConnection.Instance;
        }

        public IConnection Connect(IConnectable destination, string outputName, string inputName, IConnectionType type)
        {
            return NullConnection.Instance;
        }

        public void ConsolidateConnections()
        {
            return;
        }

        public override string ToString()
        {
            return "Null Composition";
        }
    }
}
