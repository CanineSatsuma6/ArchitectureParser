using System;
using System.Drawing;

using ArchitectureParser.Architecture.Connections.Types;

namespace ArchitectureParser.Architecture.Exceptions
{
    public class TypeAlreadyRegisteredException : Exception
    {
        public TypeAlreadyRegisteredException(Color color, IConnectionType existingType, IConnectionType newType)
            : base(string.Format("Color \"{0}\" has already been registered by type \"{1} ({2})\" and cannot be registered by type \"{3} ({4})\"", color.ToString(), (existingType as IJavaType).Name, (existingType as ICPPType).Name, (newType as IJavaType).Name, (newType as ICPPType).Name))
        {

        }
    }
}
