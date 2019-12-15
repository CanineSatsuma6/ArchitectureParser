using ArchitectureParser.Architecture.Connections.Types;
using System;
using System.Drawing;

namespace ArchitectureParser.Architecture.Exceptions
{
    public class NoSuchTypeException : Exception
    {
        public NoSuchTypeException(Color color) 
            : base(string.Format("No connection type uses color \"{0}\"", color.ToString()))
        {

        }

        public NoSuchTypeException(IConnectionType type)
            : base(string.Format("No color is associated to connection type \"{0} ({1})\"", (type as IJavaType).Name, (type as ICPPType).Name))
        {

        }

        public override string ToString()
        {
            return Message;
        }
    }
}
