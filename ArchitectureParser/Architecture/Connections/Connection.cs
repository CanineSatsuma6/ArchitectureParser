namespace ArchitectureParser.Architecture.Connections
{
    public class Connection : IConnection
    {
        // The source of the connection
        public IConnectable Source
        {
            get;
        }

        // The destination of the connection
        public IConnectable Destination
        {
            get;
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
        public Connection(IConnectable source, string sourceOutput, IConnectable destination, string destinationInput)
        {
            Source           = source;
            SourceOutput     = sourceOutput;
            Destination      = destination;
            DestinationInput = destinationInput;
        }

        public void Connect()
        {
            Source.Connections.Add(this);
            Destination.Connections.Add(this);
        }

        public override string ToString()
        {
            return string.Format("{{{0}.{1}, {2}.{3}}}", Source.ToString(), SourceOutput, Destination.ToString(), DestinationInput);
        }
    }
}
