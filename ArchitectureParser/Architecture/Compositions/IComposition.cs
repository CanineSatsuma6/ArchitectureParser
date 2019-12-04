using System.Collections.Generic;

using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.Compositions
{
    public interface IComposition : IConnectable
    {
        ISet<IConnectable> Contents { get; }
        string             Name     { get; }

        void ConsolidateConnections();
    }
}
