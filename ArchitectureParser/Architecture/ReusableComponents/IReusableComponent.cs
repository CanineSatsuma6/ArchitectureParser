using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.ReusableComponents
{
    public interface IReusableComponent : IConnectable
    {
        string InstanceName      { get; }
        string BaseComponentName { get; }
    }
}
