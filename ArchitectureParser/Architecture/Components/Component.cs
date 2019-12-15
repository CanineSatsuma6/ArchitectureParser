using System.Collections.Generic;
using System.Drawing;

using ArchitectureParser.Architecture.Connections;
using ArchitectureParser.Architecture.Connections.Types;
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
            return Name;
        }
    }
}
