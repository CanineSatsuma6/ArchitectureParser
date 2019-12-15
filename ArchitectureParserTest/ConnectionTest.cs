using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

using ArchitectureParser.Architecture.Components;
using ArchitectureParser.Architecture.Factories;
using ArchitectureParser.Architecture.Connections;
using ArchitectureParser.Architecture.Connections.Types;

namespace ArchitectureParserTest
{
    [TestClass]
    public class ConnectionTest
    {
        private static string SourceName      = @"Source";
        private static string DestinationName = @"Destination";
        private static string OutputName      = @"Output";
        private static string InputName       = @"Input";

        private static Color  Red             = Color.Red;

        private static IComponent Source()      => ComponentFactory.Create(SourceName);
        private static IComponent Destination() => ComponentFactory.Create(DestinationName);

        [TestMethod]
        public void ConnectionConstructor()
        {
            var source      = Source();
            var destination = Destination();
            var connection  = ConnectionFactory.Create(source, OutputName, destination, InputName, Red);

            Assert.AreEqual(source, connection.Source);
            Assert.AreEqual(OutputName, connection.SourceOutput);
            Assert.AreEqual(destination, connection.Destination);
            Assert.AreEqual(InputName, connection.DestinationInput);
            Assert.AreEqual(ConnectionType.Integer, connection.ConnectionType);
        }

        [TestMethod]
        public void ConnectionNullSource()
        {
            var destination = Destination();
            var connection = ConnectionFactory.Create(null, null, destination, InputName, Red);

            Assert.IsTrue(connection is NullConnection);
            Assert.AreEqual(0, destination.Connections.Count);
        }

        [TestMethod]
        public void ConnectionNullDestination()
        {
            var source = Source();
            var connection = ConnectionFactory.Create(source, OutputName, null, null, Red);

            Assert.IsTrue(connection is NullConnection);
            Assert.AreEqual(0, source.Connections.Count);
        }

        [TestMethod]
        public void ConnectionNullSourceAndDestination()
        {
            var connection = ConnectionFactory.Create(null, null, null, null, Red);

            Assert.IsTrue(connection is NullConnection);
        }
    }
}
