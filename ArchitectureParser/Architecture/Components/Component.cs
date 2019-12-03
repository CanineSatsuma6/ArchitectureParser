using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.Components
{
    public class Component : Connectable, IComponent
    {
        public Component(string name) : base(name)
        {
            // Do nothing. The Connectable class has all features needed by a component
        }
    }
}
