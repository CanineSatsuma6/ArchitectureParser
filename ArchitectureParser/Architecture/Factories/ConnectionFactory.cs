﻿using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParser.Architecture.Factories
{
    public static class ConnectionFactory
    {
        public static IConnection Create(IConnectable source, string sourceOutput, IConnectable destination, string destinationInput)
        {
            IConnection connection;

            if (source is null || sourceOutput is null || destination is null || destinationInput is null)
            {
                connection = NullConnection.Instance;
            }

            else
            {
                connection = new Connection(source, sourceOutput, destination, destinationInput);
            }

            return connection;
        }
    }
}
