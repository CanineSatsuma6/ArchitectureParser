using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.Components
{
    public class ReusableComponent : Connectable
    {
        public string InstanceName
        {
            get;
        }
        
        public ReusableComponent(string instanceName, string baseComponentName) : base(baseComponentName)
        {
            InstanceName = instanceName;
        }
    }
}
