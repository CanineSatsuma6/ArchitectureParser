using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchitectureParser.Architecture.Exceptions
{
    [Serializable]
    public class NoProvidingSourceException : Exception
    {
        public NoProvidingSourceException(string composition, params string[] neglectedConnections) 
            : base(string.Format("The following connections on composition \"{0}\" have no source component: {1}", composition, string.Join(", ", neglectedConnections)))
        {

        }

        public NoProvidingSourceException(string composition, IEnumerable<string> neglectedConnections) 
            : this(composition, neglectedConnections?.ToArray() ?? new string[0])
        {

        }

        public override string ToString()
        {
            return Message;
        }
    }
}
