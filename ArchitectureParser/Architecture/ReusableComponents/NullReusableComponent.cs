using System.Collections.Generic;
using System.Drawing;

using ArchitectureParser.Architecture.Connections;
using ArchitectureParser.Architecture.Connections.Types;
using ArchitectureParser.Architecture.NullObjects;


namespace ArchitectureParser.Architecture.ReusableComponents
{
    public sealed class NullReusableComponent : IReusableComponent
    {
        private static NullReusableComponent m_instance;
        public  static NullReusableComponent Instance { get { return m_instance ?? (m_instance = new NullReusableComponent()); } }

        private NullSet<IConnection> m_connections;

        public string BaseComponentName
        {
            get { return string.Empty; }
        }

        public string InstanceName
        {
            get { return string.Empty; }
        }

        public ISet<IConnection> Connections
        {
            get { return m_connections; }
        }

        private NullReusableComponent()
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
            return "Null Reusable Component";
        }
    }
}
