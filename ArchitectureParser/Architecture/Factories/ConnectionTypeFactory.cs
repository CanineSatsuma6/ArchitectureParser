using System.Collections.Generic;
using System.Drawing;

using ArchitectureParser.Architecture.Connections.Types;
using ArchitectureParser.Architecture.Exceptions;

namespace ArchitectureParser.Architecture.Factories
{
    public static class ConnectionTypeFactory
    {
        private static Dictionary<Color, IConnectionType> m_types = new Dictionary<Color, IConnectionType>()
                                                                  {
                                                                      { Color.Red,    ConnectionType.Integer },
                                                                      { Color.Blue,   ConnectionType.Double  },
                                                                      { Color.Green,  ConnectionType.Boolean },
                                                                      { Color.Yellow, ConnectionType.String  }
                                                                  };

        public static void RegisterType(Color color, IConnectionType type)
        {
            if (m_types.ContainsKey(color))
            {
                throw new TypeAlreadyRegisteredException(color, m_types[color], type);
            }

            m_types.Add(color, type);
        }

        public static IJavaType GetJavaType(Color color)
        {
            return GetType(color) as IJavaType;
        }

        public static ICPPType GetCPPType(Color color)
        {
            return GetType(color) as ICPPType;
        }

        public static IConnectionType GetType(Color color)
        {
            IConnectionType type;

            if (m_types.ContainsKey(color))
            {
                type = m_types[color];
            }

            else
            {
                throw new NoSuchTypeException(color);
            }

            return type;
        }

        public static void ClearTypes()
        {
            m_types = new Dictionary<Color, IConnectionType>()
                          {
                              { Color.Red,    ConnectionType.Integer },
                              { Color.Blue,   ConnectionType.Double  },
                              { Color.Green,  ConnectionType.Boolean },
                              { Color.Yellow, ConnectionType.String  }
                          };
        }
    }
}
