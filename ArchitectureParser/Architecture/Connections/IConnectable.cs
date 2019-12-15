using System.Collections.Generic;
using System.Drawing;

using ArchitectureParser.Architecture.Connections.Types;

namespace ArchitectureParser.Architecture.Connections
{
    public interface IConnectable
    {
        ISet<IConnection> Connections { get; }

        IConnection Connect(IConnectable destination, string outputName, string inputName, Color type);
        IConnection Connect(IConnectable destination, string outputName, string inputName, IConnectionType type);
    }
}
