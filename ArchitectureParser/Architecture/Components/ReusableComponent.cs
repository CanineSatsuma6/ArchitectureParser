using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.Components
{
    public class ReusableComponent : Component, IReusable, IConnectable
    {
        // Property for the Instance name of the reusable component. Required by IReusable
        public new string Name 
        { 
            get; 
        }

        // When interpreted as an IConnectable, the Name property will be the BaseComponentName
        string IConnectable.Name
        {
            get { return BaseComponentName; }
        }

        // Property for the Base Component Name of the reusable component. Required by IReusable
        public string BaseComponentName 
        { 
            get; 
        }

        // The constructor creates a reusable component with the given instance and base component names
        public ReusableComponent(string instanceName, string baseComponentName) : base(null)
        {
            Name              = instanceName;
            BaseComponentName = baseComponentName;
        }
    }
}
