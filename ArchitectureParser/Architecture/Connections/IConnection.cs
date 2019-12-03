namespace ArchitectureParser.Architecture.Connections
{
    public interface IConnection
    {
        IConnectable Source           { get; }
        string       SourceOutput     { get; set; }
        IConnectable Destination      { get; }
        string       DestinationInput { get; set; }

        void Connect();
    }
}
