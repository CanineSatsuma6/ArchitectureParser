using ArchitectureParser.Generators.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureParser.Generators.Builders
{
    public class JavaBuilder
    {
        private ExpressionBlock m_currentBlock;

        public JavaBuilder StartClass()
        {
            return this;
        }


    }
}
