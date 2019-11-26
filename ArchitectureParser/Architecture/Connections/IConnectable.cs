using System.Collections.Generic;

namespace ArchitectureParser.Architecture.Connections
{
    public interface IConnectable
    {
        // Properties
        string           Name        { get; }
        ISet<Connection> Connections { get; }

        // Methods
        Connection Connect(IConnectable destination);
    }
}
