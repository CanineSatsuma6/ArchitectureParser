using System;
using System.Collections.Generic;
using System.Linq;

using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.Components
{
    public class Composition : IConnectable
    {
        private HashSet<Connection>   m_connections;
        private HashSet<IConnectable> m_contents;

        public string Name
        {
            get;
        }

        public ISet<Connection> Connections
        {
            get { return m_connections; }
        }

        public ISet<IConnectable> Contents
        {
            get { return m_contents; }
        }

        public Composition(string name)
        {
            Name          = name;
            m_connections = new HashSet<Connection>();
            m_contents    = new HashSet<IConnectable>();
        }

        public Connection Connect(IConnectable destination, string output, string input)
        {
            var connection = new Connection(this, output, destination, input);

            Connections.Add(connection);
            destination.Connections.Add(connection);

            return connection;
        }

        // This method effectively removes the composition from the component tree.
        // It's intended for this Composition to be discarded shortly after calling this method
        public void ConsolidateConnections()
        {
            // Ensure components consuming composition inputs/outputs have a source

            // Find connections that are consumed by internal components but are not provided by external components
            var neglectedInternalConnections = from c in Connections where c.Source == this && Contents.Contains(c.Destination) && !Connections.Any(con => con.DestinationInput == c.SourceOutput) select c;

            if (neglectedInternalConnections.Count() > 0)
            {
                throw new NullReferenceException(string.Format("These inputs on composition \"{0}\" are not provided externally: {1}", Name, string.Join(", ", from c in neglectedInternalConnections select c.SourceOutput)));
            }

            // Find connections that are consumed by external components but are not provided by internal components
            var neglectedExternalConnections = from c in Connections where c.Source == this && !Contents.Contains(c.Destination) && c.Destination != this && !Connections.Any(con => con.DestinationInput == c.SourceOutput) select c;

            if (neglectedExternalConnections.Count() > 0)
            {
                throw new NullReferenceException(string.Format("These outputs on composition \"{0}\" are not provided internally: {1}", Name, string.Join(", ", from c in neglectedExternalConnections select c.SourceOutput)));
            }

            // Begin consolidating composition connections

            // First, consolidate the connections leading into the composition
            var incomingConnections = from c in Connections where c.Destination == this && !Contents.Contains(c.Source) && c.Source != this select c;

            foreach (var connection in incomingConnections)
            {
                // Find all of the places this input is consumed
                var destinationConnections = from c in Connections where c.Source == this && c.SourceOutput == connection.DestinationInput select c;

                foreach (var destinationConnection in destinationConnections)
                {
                    // If the input passes through straight to an output, connect the input to the external components
                    if (destinationConnection.Destination == this)
                    {
                        var externalDestinationConnections = from c in Connections where c.Source == this && c.SourceOutput == destinationConnection.DestinationInput select c;

                        foreach (var externalDestinationConnection in externalDestinationConnections)
                        {
                            connection.Source.Connect(externalDestinationConnection.Destination, connection.SourceOutput, externalDestinationConnection.DestinationInput);
                            externalDestinationConnection.Destination.Connections.Remove(externalDestinationConnection);
                        }
                    }

                    // If the input connects to a component, connect the input to that component
                    else
                    {
                        connection.Source.Connect(destinationConnection.Destination, connection.SourceOutput, destinationConnection.DestinationInput);
                        destinationConnection.Destination.Connections.Remove(destinationConnection);
                    }
                }

                connection.Source.Connections.Remove(connection);
            }

            // Then, consolidate the connections leading out of the composition
            var outgoingConnections = from c in Connections where c.Destination == this && Contents.Contains(c.Source) select c;

            foreach (var connection in outgoingConnections)
            {
                var destinationConnections = from c in Connections where c.Source == this && c.SourceOutput == connection.DestinationInput select c;

                foreach (var destinationConnection in destinationConnections)
                {
                    connection.Source.Connect(destinationConnection.Destination, connection.SourceOutput, destinationConnection.DestinationInput);
                    destinationConnection.Destination.Connections.Remove(destinationConnection);
                }

                connection.Source.Connections.Remove(connection);
            }

            // Remove all connections and content from the composition
            Connections.Clear();
            Contents.Clear();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
