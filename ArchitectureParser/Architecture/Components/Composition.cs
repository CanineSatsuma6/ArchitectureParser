using System.Collections.Generic;

using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.Components
{
    public class Composition : CompositionBase
    {
        private HashSet<Connectable> m_contents;

        public override ISet<Connectable> Contents
        {
            get { return m_contents; }
        }

        public Composition(string name) : base(name)
        {
            m_contents = new HashSet<Connectable>();
        }
    }
}
