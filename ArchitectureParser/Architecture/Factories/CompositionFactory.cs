using ArchitectureParser.Architecture.Components;
using ArchitectureParser.Architecture.NullObjects;

namespace ArchitectureParser.Architecture.Factories
{
    public static class CompositionFactory
    {
        public static CompositionBase Create(string name)
        {
            CompositionBase composition;

            if (string.IsNullOrWhiteSpace(name))
            {
                composition = new NullComposition();
            }

            else
            {
                composition = new Composition(name);
            }

            return composition;
        }
    }
}
