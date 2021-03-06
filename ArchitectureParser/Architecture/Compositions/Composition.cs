﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using ArchitectureParser.Architecture.Connections;
using ArchitectureParser.Architecture.Connections.Types;
using ArchitectureParser.Architecture.Exceptions;
using ArchitectureParser.Architecture.Factories;

namespace ArchitectureParser.Architecture.Compositions
{
    public class Composition : IComposition
    {
        private HashSet<IConnectable> m_contents;
        private HashSet<IConnection>  m_connections;

        public string Name
        {
            get;
        }

        public ISet<IConnectable> Contents
        {
            get { return m_contents; }
        }

        public ISet<IConnection> Connections
        {
            get { return m_connections; }
        }

        public Composition(string name)
        {
            Name          = name;
            m_contents    = new HashSet<IConnectable>();
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

        public void ConsolidateConnections()
        {
            // Ensure components consuming composition inputs/outputs have a source

            // Find connections that are consumed by internal components but are not provided by external components
            var neglectedInternalConnections = from c in Connections
                                               where c.Source == this
                                               where Contents.Contains(c.Destination)
                                               where !Connections.Any(con => con.DestinationInput == c.SourceOutput)
                                               select c;

            if (neglectedInternalConnections.Any())
            {
                throw new NoProvidingSourceException(Name, from c in neglectedInternalConnections select c.SourceOutput);
            }

            // Find connections that are consumed by external components but are not provided by internal components
            var neglectedExternalConnections = from c in Connections
                                               where c.Source == this
                                               where c.Destination != this
                                               where !Contents.Contains(c.Destination)
                                               where !Connections.Any(con => con.DestinationInput == c.SourceOutput)
                                               select c;

            if (neglectedExternalConnections.Any())
            {
                throw new NoProvidingSourceException(Name, from c in neglectedExternalConnections select c.SourceOutput);
            }

            // Begin consolidating composition connections

            // First, consolidate the connections leading into the composition
            var incomingConnections = from c in Connections
                                      where c.Destination == this
                                      where c.Source != this
                                      where !Contents.Contains(c.Source)
                                      select c;

            foreach (var connection in incomingConnections)
            {
                // Find all of the places this input is consumed
                var destinationConnections = from c in Connections
                                             where c.Source == this
                                             where c.SourceOutput == connection.DestinationInput
                                             select c;

                foreach (var destinationConnection in destinationConnections)
                {
                    var trueDestinations = Enumerable.Repeat(destinationConnection, 1);

                    // If the input passes through straight to an output, connect the input to the external components
                    if (destinationConnection.Destination == this)
                    {
                        trueDestinations = from c in Connections
                                           where c.Source == this
                                           where c.SourceOutput == destinationConnection.DestinationInput
                                           select c;
                    }

                    // Connect the source to the current destination and remove the destination's connection to the composition
                    foreach (var trueDestination in trueDestinations)
                    {
                        connection.Source.Connect(trueDestination.Destination, connection.SourceOutput, trueDestination.DestinationInput, connection.ConnectionType);
                        trueDestination.Destination.Connections.Remove(trueDestination);
                    }
                }

                // Remove the source's connection to the composition
                connection.Source.Connections.Remove(connection);
            }

            // Then, consolidate the connections leading out of the composition
            var outgoingConnections = from c in Connections
                                      where c.Destination == this
                                      where Contents.Contains(c.Source)
                                      select c;

            foreach (var connection in outgoingConnections)
            {
                var destinationConnections = from c in Connections
                                             where c.Source == this
                                             where c.SourceOutput == connection.DestinationInput
                                             select c;

                foreach (var destinationConnection in destinationConnections)
                {
                    connection.Source.Connect(destinationConnection.Destination, connection.SourceOutput, destinationConnection.DestinationInput, connection.ConnectionType);
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
