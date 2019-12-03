using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.Components
{
    public interface IComponent : IConnectable
    {
        string Name { get; }
    }
}
