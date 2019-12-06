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

        public override string ToString()
        {
            return Message;
        }
    }
}
