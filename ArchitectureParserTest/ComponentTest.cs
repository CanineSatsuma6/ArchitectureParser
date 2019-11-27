using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using ArchitectureParser.Architecture.Components;

namespace ArchitectureParserTest
{
    [TestClass]
    public class ComponentTest
    {
        [TestMethod]
        public void ComponentConstructor()
        {
            var component = new Component("Test");

            Assert.AreEqual("Test", component.Name);
            Assert.AreEqual(0,      component.Connections.Count);
        }

        [TestMethod]
        public void ComponentConnect()
        {
            var component = new Component("Test");
            var destination = new Component("Destination");

            var connection = component.Connect(destination, "Output", "Input");

            Assert.AreEqual(component, connection.Source);
            Assert.AreEqual(destination, connection.Destination);
            Assert.AreEqual(1, component.Connections.Count);
            Assert.AreEqual(1, component.Connections.Count);
            Assert.IsTrue(component.Connections.Contains(connection));
            Assert.IsTrue(destination.Connections.Contains(connection));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ComponentConnectToNullDestination()
        {
            var component = new Component("Test");
            var connection = component.Connect(null, null, null);
        }
    }
}
