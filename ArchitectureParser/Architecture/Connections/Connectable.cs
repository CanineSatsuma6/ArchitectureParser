using System.Collections.Generic;

namespace ArchitectureParser.Architecture.Connections
{
    public abstract class Connectable
    {
        private HashSet<Connection> m_connections;

        public string Name
        {
            get;
        }

        public ISet<Connection> Connections
        {
            get { return m_connections; }
        }

        public Connectable(string name)
        {
            Name          = name;
            m_connections = new HashSet<Connection>();
        }

        public virtual Connection Connect(Connectable destination, string outputName, string inputName)
        {
            var connection = new Connection(this, outputName, destination, inputName);

            Connections.Add(connection);
            destination.Connections.Add(connection);

            return connection;
        }
    }
}
