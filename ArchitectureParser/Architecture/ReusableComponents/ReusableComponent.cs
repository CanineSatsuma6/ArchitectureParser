using System.Collections.Generic;

using ArchitectureParser.Architecture.Connections;
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

        public IConnection Connect(IConnectable destination, string outputName, string inputName)
        {
            var connection = ConnectionFactory.Create(this, outputName, destination, inputName);

            connection.Connect();

            return connection;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", InstanceName, BaseComponentName);
        }
    }
}
