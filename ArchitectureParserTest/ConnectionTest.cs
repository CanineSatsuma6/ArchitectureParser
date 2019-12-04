using Microsoft.VisualStudio.TestTools.UnitTesting;

using ArchitectureParser.Architecture.Components;
using ArchitectureParser.Architecture.Factories;
using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParserTest
{
    [TestClass]
    public class ConnectionTest
    {
        private static string SourceName      = @"Source";
        private static string DestinationName = @"Destination";
        private static string OutputName      = @"Output";
        private static string InputName       = @"Input";

        private static IComponent Source()      => ComponentFactory.Create(SourceName);
        private static IComponent Destination() => ComponentFactory.Create(DestinationName);

        [TestMethod]
        public void ConnectionConstructor()
        {
            var source      = Source();
            var destination = Destination();
            var connection  = ConnectionFactory.Create(source, OutputName, destination, InputName);

            Assert.AreEqual(source, connection.Source);
            Assert.AreEqual(OutputName, connection.SourceOutput);
            Assert.AreEqual(destination, connection.Destination);
            Assert.AreEqual(InputName, connection.DestinationInput);
        }

        [TestMethod]
        public void ConnectionNullSource()
        {
            var destination = Destination();
            var connection = ConnectionFactory.Create(null, null, destination, InputName);

            Assert.IsTrue(connection is NullConnection);
            Assert.AreEqual(0, destination.Connections.Count);
        }

        [TestMethod]
        public void ConnectionNullDestination()
        {
            var source = Source();
            var connection = ConnectionFactory.Create(source, OutputName, null, null);

            Assert.IsTrue(connection is NullConnection);
            Assert.AreEqual(0, source.Connections.Count);
        }

        [TestMethod]
        public void ConnectionNullSourceAndDestination()
        {
            var connection = ConnectionFactory.Create(null, null, null, null);

            Assert.IsTrue(connection is NullConnection);
        }
    }
}
