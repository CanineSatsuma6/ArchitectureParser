using ArchitectureParser.Architecture.ReusableComponents;

namespace ArchitectureParser.Architecture.Factories
{
    public static class ReusableComponentFactory
    {
        public static IReusableComponent Create(string instanceName, string baseName)
        {
            IReusableComponent reusableComponent;

            if (string.IsNullOrWhiteSpace(instanceName) || string.IsNullOrWhiteSpace(baseName))
            {
                reusableComponent = NullReusableComponent.Instance;
            }

            else
            {
                reusableComponent = new ReusableComponent(instanceName, baseName);
            }

            return reusableComponent;
        }
    }
}
