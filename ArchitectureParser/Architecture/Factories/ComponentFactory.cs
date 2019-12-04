using ArchitectureParser.Architecture.Components;
using ArchitectureParser.Architecture.ReusableComponents;

namespace ArchitectureParser.Architecture.Factories
{
    public static class ComponentFactory
    {
        public static IComponent Create(string name)
        {
            IComponent component;

            if (string.IsNullOrWhiteSpace(name))
            {
                component = NullComponent.Instance;
            }

            else if (name.Replace("<br>", " ").Replace("\r", "").Replace("\n", " ").Contains(" "))
            {
                var nameParts = name.Replace("<br>", " ").Replace("\r", "").Replace("\n", " ").Split();
                var instanceName = nameParts[0];
                var componentName = nameParts[1];

                component = new ReusableComponent(instanceName, componentName);
            }

            else
            {
                component = new Component(name);
            }

            return component;
        }
    }
}
