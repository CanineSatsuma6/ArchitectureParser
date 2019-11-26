using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using ArchitectureParser.Architecture.Components;
using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParserTest
{
    [TestClass]
    public class ConnectionTest
    {
        [TestMethod]
        public void ConnectionConstructor()
        {
            var source      = new Component("Source");
            var destination = new Component("Destination");
            var connection  = new Connection(source, destination);

            Assert.AreEqual(source, connection.Source);
            Assert.AreEqual(destination, connection.Destination);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConnectionNullSource()
        {
            var destination = new Component("Destination");
            var connection = new Connection(null, destination);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConnectionNullDestination()
        {
            var source = new Component("Source");
            var connection = new Connection(source, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConnectionNullSourceAndDestination()
        {
            var connection = new Connection(null, null);
        }
    }
}
