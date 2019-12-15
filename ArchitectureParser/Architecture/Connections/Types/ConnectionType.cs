namespace ArchitectureParser.Architecture.Connections.Types
{
    public class ConnectionType : IConnectionType
    {
        public static readonly ConnectionType Integer = new ConnectionType("int",     "int",         "0",     "0");
        public static readonly ConnectionType Double  = new ConnectionType("double",  "double",      "0.0",   "0.0");
        public static readonly ConnectionType Boolean = new ConnectionType("boolean", "bool",        "false", "false");
        public static readonly ConnectionType String  = new ConnectionType("String",  "std::string", "\"\"",  "\"\"");

        private string m_javaName;
        private string m_javaDefault;
        private string m_cppName;
        private string m_cppDefault;

        string IJavaType.Name
        {
            get;
        }

        string ICPPType.Name
        {
            get;
        }

        string IJavaType.DefaultValue
        {
            get;
        }

        string ICPPType.DefaultValue
        {
            get;
        }

        public ConnectionType(string javaName, string cppName, string javaDefault, string cppDefault)
        {
            m_javaName    = javaName;
            m_javaDefault = javaDefault;

            m_cppName     = cppName;
            m_cppDefault  = cppDefault;
        }
    }
}
