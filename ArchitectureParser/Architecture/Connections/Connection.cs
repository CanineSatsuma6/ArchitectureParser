using System;

namespace ArchitectureParser.Architecture.Connections
{
    public class Connection : IConnection
    {
        // The source of the connection
        public Connectable Source
        {
            get;
            set;
        }

        // The destination of the connection
        public Connectable Destination
        {
            get;
            set;
        }

        // The name of the output of the Source
        public string SourceOutput
        {
            get;
            set;
        }

        // The name of the input of the Destination
        public string DestinationInput
        {
            get;
            set;
        }

        // The constructor creates a Connection from the source to the destination
        public Connection(Connectable source, string sourceOutput, Connectable destination, string destinationInput)
        {
            Source           = source;
            SourceOutput     = sourceOutput;
            Destination      = destination;
            DestinationInput = destinationInput;
        }

        public override string ToString()
        {
            return string.Format("{{{0}.{1}, {2}.{3}}}", Source.Name, SourceOutput, Destination.Name, DestinationInput);
        }
    }
}
