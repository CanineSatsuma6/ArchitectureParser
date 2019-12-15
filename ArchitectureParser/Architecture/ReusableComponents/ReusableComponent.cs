using System.Collections.Generic;
using System.Drawing;

using ArchitectureParser.Architecture.Connections;
using ArchitectureParser.Architecture.Connections.Types;
using ArchitectureParser.Architecture.Factories;

namespace ArchitectureParser.Architecture.ReusableComponents
{
    public class ReusableComponent : IReusableComponent
    {
        private HashSet<IConnection> m_connections;

        public string BaseComponentName
        {
            get;
        }

        public string InstanceName
        {
            get;
        }

        public ISet<IConnection> Connections
        {
            get { return m_connections; }
        }
        
        public ReusableComponent(string instanceName, string baseComponentName)
        {
            InstanceName      = instanceName;
            BaseComponentName = baseComponentName;
            m_connections     = new HashSet<IConnection>();
        }

        public IConnection Connect(IConnectable destination, string outputName, string inputName, Color type)
        {
            var connection = ConnectionFactory.Create(this, outputName, destination, inputName, type);

            connection.Connect();

            return connection;
        }

        public IConnection Connect(IConnectable destination, string outputName, string inputName, IConnectionType type)
        {
            return Connect(destination, outputName, inputName, ConnectionTypeFactory.GetColor(type));
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", InstanceName, BaseComponentName);
        }
    }
}
