using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using ArchitectureParser.Architecture.Components;
using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParserTest
{
    [TestClass]
    public class ReusableComponentTest
    {
        [TestMethod]
        public void ReusableComponentConstructor()
        {
            var reusableComponent = new ReusableComponent("Instance", "Base");

            Assert.AreEqual("Instance", reusableComponent.InstanceName);
            Assert.AreEqual("Base",     reusableComponent.Name);
            Assert.AreEqual(0,          reusableComponent.Connections.Count);
        }

        [TestMethod]
        public void ReusableComponentConnect()
        {
            var reusableComponent = new ReusableComponent("Instance", "Base");
            var component         = new Component("Component");
            var connection        = reusableComponent.Connect(component, "Output", "Input");

            Assert.AreEqual(reusableComponent, connection.Source);
            Assert.AreEqual(component, connection.Destination);
            Assert.AreEqual(1, reusableComponent.Connections.Count);
            Assert.AreEqual(1, component.Connections.Count);
            Assert.IsTrue(reusableComponent.Connections.Contains(connection));
            Assert.IsTrue(component.Connections.Contains(connection));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReusableComponentConnectToNullDestination()
        {
            var reusableComponent = new ReusableComponent("Instance", "Base");
            var connection = reusableComponent.Connect(null, "Output", null);
        }
    }
}
