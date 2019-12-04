using ArchitectureParser.Architecture.Components;

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

            else
            {
                component = new Component(name);
            }

            return component;
        }
    }
}
