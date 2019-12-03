using System.Collections.Generic;

namespace ArchitectureParser.Architecture.Connections
{
    public interface IConnectable
    {
        ISet<IConnection> Connections { get; }

        IConnection Connect(IConnectable destination, string outputName, string inputName);
    }
}
