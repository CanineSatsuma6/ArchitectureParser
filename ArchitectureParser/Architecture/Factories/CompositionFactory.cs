using ArchitectureParser.Architecture.Compositions;

namespace ArchitectureParser.Architecture.Factories
{
    public static class CompositionFactory
    {
        public static IComposition Create(string name)
        {
            IComposition composition;

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
