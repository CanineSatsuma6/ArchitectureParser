using System.Collections.Generic;

using ArchitectureParser.Architecture.Connections;
using ArchitectureParser.Architecture.Factories;

namespace ArchitectureParser.Architecture.Components
{
    public class Component : IComponent
    {
        private HashSet<IConnection> m_connections;

        public ISet<IConnection> Connections
        {
            get { return m_connections; }
        }

        public string Name { get; }

        public Component(string name)
        {
            Name = name;
            m_connections = new HashSet<IConnection>();
        }

        public IConnection Connect(IConnectable destination, string outputName, string inputName)
        {
            var connection = ConnectionFactory.Create(this, outputName, destination, inputName);

            connection.Connect();

            return connection;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
