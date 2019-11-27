using System;

namespace ArchitectureParser.Architecture.Connections
{
    public class Connection
    {
        // The source of the connection
        public IConnectable Source
        {
            get;
            set;
        }

        // The destination of the connection
        public IConnectable Destination
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
        public Connection(IConnectable source = null, string sourceOutput = null, IConnectable destination = null, string destinationInput = null)
        {
            if (source is null)           throw new ArgumentNullException("Cannot connect to null source");
            if (sourceOutput is null)     throw new ArgumentNullException("Source output must have a name");
            if (destination is null)      throw new ArgumentNullException("Cannot connect to null destination");
            if (destinationInput is null) throw new ArgumentNullException("Destination input must have a name");

            Source           = source;
            SourceOutput     = sourceOutput;
            Destination      = destination;
            DestinationInput = destinationInput;
        }
    }
}
