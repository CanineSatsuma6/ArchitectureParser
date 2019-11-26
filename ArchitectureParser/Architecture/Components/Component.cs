using System;
using System.Collections.Generic;

using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.Components
{
    public class Component : IConnectable
    {
        // Private backing field for the Connections property
        private HashSet<Connection> m_connections;

        // Property for the component name. Required by IConnectable
        public string Name 
        { 
            get; 
        }

        // Property for the component connections. Required by IConnectable
        public ISet<Connection> Connections 
        { 
            get { return m_connections; }
        }

        // The constructor creates a component with the given name
        public Component(string name)
        {
            Name          = name;
            m_connections = new HashSet<Connection>();
        }

        // Creates and returns a connection with this component as the source
        // and the provided IConnectable as the destination
        public Connection Connect(IConnectable destination)
        {
            var connection = new Connection(this, destination);

            Connections.Add(connection);
            destination.Connections.Add(connection);

            return connection;
        }
    }
}
