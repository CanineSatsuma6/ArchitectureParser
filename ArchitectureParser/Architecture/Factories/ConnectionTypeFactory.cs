using System.Collections.Generic;
using System.Drawing;

using ArchitectureParser.Architecture.Connections.Types;
using ArchitectureParser.Architecture.Exceptions;

namespace ArchitectureParser.Architecture.Factories
{
    public static class ConnectionTypeFactory
    {
        private static Dictionary<Color, IJavaType> m_javaTypes = new Dictionary<Color, IJavaType>()
                                                                  {
                                                                      { Color.Red,    ConnectionType.Integer },
                                                                      { Color.Blue,   ConnectionType.Double  },
                                                                      { Color.Green,  ConnectionType.Boolean },
                                                                      { Color.Yellow, ConnectionType.String  }
                                                                  };

        private static Dictionary<Color, ICPPType>  m_cppTypes  = new Dictionary<Color, ICPPType>()
                                                                  {
                                                                      { Color.Red,    ConnectionType.Integer },
                                                                      { Color.Blue,   ConnectionType.Double  },
                                                                      { Color.Green,  ConnectionType.Boolean },
                                                                      { Color.Yellow, ConnectionType.String  }
                                                                  };

        public static void RegisterJavaType(Color color, IJavaType type)
        {
            if (m_javaTypes.ContainsKey(color))
            {
                throw new TypeAlreadyRegisteredException(color, m_javaTypes[color], type);
            }

            m_javaTypes.Add(color, type);
        }

        public static IJavaType GetJavaType(Color color)
        {
            IJavaType type;

            if (m_javaTypes.ContainsKey(color))
            {
                type = m_javaTypes[color];
            }

            else
            {
                throw new NoSuchTypeException(color);
            }

            return type;
        }

        public static void ClearJavaTypes()
        {
            m_javaTypes = new Dictionary<Color, IJavaType>()
            {
                { Color.Red,    ConnectionType.Integer },
                { Color.Blue,   ConnectionType.Double  },
                { Color.Green,  ConnectionType.Boolean },
                { Color.Yellow, ConnectionType.String  }
            };
        }

        public static void RegisterCppType(Color color, ICPPType type)
        {
            if (m_cppTypes.ContainsKey(color))
            {
                throw new TypeAlreadyRegisteredException(color, m_cppTypes[color], type);
            }

            m_cppTypes.Add(color, type);
        }

        public static ICPPType GetCPPType(Color color)
        {
            ICPPType type;

            if (m_cppTypes.ContainsKey(color))
            {
                type = m_cppTypes[color];
            }

            else
            {
                throw new NoSuchTypeException(color);
            }

            return type;
        }

        public static void ClearCPPTypes()
        {
            m_cppTypes = new Dictionary<Color, ICPPType>()
            {
                { Color.Red,    ConnectionType.Integer },
                { Color.Blue,   ConnectionType.Double  },
                { Color.Green,  ConnectionType.Boolean },
                { Color.Yellow, ConnectionType.String  }
            };
        }
    }
}
