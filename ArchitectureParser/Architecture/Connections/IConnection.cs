namespace ArchitectureParser.Architecture.Connections
{
    public interface IConnection
    {
        Connectable Source           { get; set; }
        string      SourceOutput     { get; set; }
        Connectable Destination      { get; set; }
        string      DestinationInput { get; set; }
    }
}
