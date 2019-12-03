using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.Components
{
    public class ReusableComponent : Connectable, IComponent
    {
        public string InstanceName
        {
            get;
        }
        
        public ReusableComponent(string instanceName, string baseComponentName) : base(baseComponentName)
        {
            InstanceName = instanceName;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", InstanceName, Name);
        }
    }
}
