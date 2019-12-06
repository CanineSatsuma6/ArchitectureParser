using System;
using System.Drawing;

using ArchitectureParser.Architecture.Connections.Types;

namespace ArchitectureParser.Architecture.Exceptions
{
    public class TypeAlreadyRegisteredException : Exception
    {
        public TypeAlreadyRegisteredException(Color color, IJavaType existingType, IJavaType newType)
            : base(string.Format("Color \"{0}\" has already been registered by type \"{1}\" and cannot be registered by type \"{2}\"", color.ToString(), existingType.Name, newType.Name))
        {

        }

        public TypeAlreadyRegisteredException(Color color, ICPPType existingType, ICPPType newType)
            : base(string.Format("Color \"{0}\" has already been registered by type \"{1}\" and cannot be registered by type \"{2}\"", color.ToString(), existingType.Name, newType.Name))
        {

        }
    }
}
