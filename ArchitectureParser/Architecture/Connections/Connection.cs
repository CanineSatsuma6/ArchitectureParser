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

        // The constructor creates a Connection from the source to the destination
        public Connection(IConnectable source = null, IConnectable destination = null)
        {
            if (source is null)      throw new ArgumentNullException("Cannot connect to null source");
            if (destination is null) throw new ArgumentNullException("Cannot connect to null destination");

            Source      = source;
            Destination = destination;
        }
    }
}
