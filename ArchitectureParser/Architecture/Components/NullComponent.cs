using System.Collections.Generic;
using System.Drawing;

using ArchitectureParser.Architecture.Connections;
using ArchitectureParser.Architecture.Connections.Types;
using ArchitectureParser.Architecture.NullObjects;

namespace ArchitectureParser.Architecture.Components
{
    public sealed class NullComponent : IComponent
    {
        private static NullComponent m_instance;
        public  static NullComponent Instance { get { return m_instance ?? (m_instance = new NullComponent()); } }

        private NullSet<IConnection> m_connections;

        public string Name
        {
            get { return string.Empty; }
        }

        public ISet<IConnection> Connections
        {
            get { return m_connections; }
        }

        private NullComponent()
        {
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

        public override string ToString()
        {
            return "Null Component";
        }
    }
}
