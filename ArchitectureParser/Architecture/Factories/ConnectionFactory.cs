using ArchitectureParser.Architecture.Connections;
using ArchitectureParser.Architecture.NullObjects;

namespace ArchitectureParser.Architecture.Factories
{
    public static class ConnectionFactory
    {
        public static IConnection Create(Connectable source, string sourceOutput, Connectable destination, string destinationInput)
        {
            IConnection connection;

            if (source is null || sourceOutput is null || destination is null || destinationInput is null)
            {
                connection = new NullConnection();
            }

            else
            {
                connection = new Connection(source, sourceOutput, destination, destinationInput);
            }

            return connection;
        }
    }
}
