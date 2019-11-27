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
            var connection  = new Connection(source, "Output", destination, "Input");

            Assert.AreEqual(source, connection.Source);
            Assert.AreEqual("Output", connection.SourceOutput);
            Assert.AreEqual(destination, connection.Destination);
            Assert.AreEqual("Input", connection.DestinationInput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConnectionNullSource()
        {
            var destination = new Component("Destination");
            var connection = new Connection(null, null, destination, "Input");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConnectionNullDestination()
        {
            var source = new Component("Source");
            var connection = new Connection(source, "Output", null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConnectionNullSourceAndDestination()
        {
            var connection = new Connection(null, null, null, null);
        }
    }
}
