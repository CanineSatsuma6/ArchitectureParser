using System.Collections.Generic;

using ArchitectureParser.Architecture.Factories;
using ArchitectureParser.Architecture.NullObjects;

namespace ArchitectureParser.Architecture.Connections
{
    public abstract class Connectable
    {
        private HashSet<IConnection> m_connections;

        public string Name
        {
            get;
        }

        public virtual ISet<IConnection> Connections
        {
            get { return m_connections; }
        }

        public Connectable(string name)
        {
            Name          = name;
            m_connections = new HashSet<IConnection>();
        }

        public IConnection Connect(Connectable destination, string outputName, string inputName)
        {
            var connection = ConnectionFactory.Create(this, outputName, destination, inputName);

            if (!(connection is NullConnection))
            {
                Connections.Add(connection);
                destination.Connections.Add(connection);
            }

            return connection;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
