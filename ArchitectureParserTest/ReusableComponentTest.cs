using Microsoft.VisualStudio.TestTools.UnitTesting;

using ArchitectureParser.Architecture.Components;
using ArchitectureParser.Architecture.Factories;
using ArchitectureParser.Architecture.ReusableComponents;
using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParserTest
{
    [TestClass]
    public class ReusableComponentTest
    {
        private static string InstanceName = @"Instance";
        private static string BaseName     = @"Base";

        private static string ComponentName = @"Component";

        private static string InputName  = @"Input";
        private static string OutputName = @"Output";

        private static IComponent ComponentBreak()   => ComponentFactory.Create(string.Format("{0}<br>{1}", InstanceName, BaseName));
        private static IComponent ComponentNewline() => ComponentFactory.Create(string.Format("{0}\n{1}", InstanceName, BaseName));

        private static IComponent Component() => ComponentFactory.Create(ComponentName);

        [TestMethod]
        public void ReusableComponentConstructor()
        {
            var reusableComponent = ComponentBreak() as ReusableComponent;

            Assert.AreEqual(InstanceName, reusableComponent.InstanceName);
            Assert.AreEqual(BaseName,     reusableComponent.Name);
            Assert.AreEqual(0,            reusableComponent.Connections.Count);
        }

        [TestMethod]
        public void ReusableComponentConstructor2()
        {
            var reusableComponent = ComponentNewline() as ReusableComponent;

            Assert.AreEqual(InstanceName, reusableComponent.InstanceName);
            Assert.AreEqual(BaseName, reusableComponent.Name);
            Assert.AreEqual(0, reusableComponent.Connections.Count);
        }

        [TestMethod]
        public void ReusableComponentConnect()
        {
            var reusableComponent = ComponentBreak() as ReusableComponent;
            var component         = Component();
            var connection        = reusableComponent.Connect(component, OutputName, InputName);

            Assert.AreEqual(reusableComponent, connection.Source);
            Assert.AreEqual(component, connection.Destination);
            Assert.AreEqual(1, reusableComponent.Connections.Count);
            Assert.AreEqual(1, component.Connections.Count);
            Assert.IsTrue(reusableComponent.Connections.Contains(connection));
            Assert.IsTrue(component.Connections.Contains(connection));
        }

        [TestMethod]
        public void ReusableComponentConnectToNullDestination()
        {
            var reusableComponent = ComponentBreak() as ReusableComponent;
            var connection = reusableComponent.Connect(null, OutputName, null);

            Assert.IsTrue(connection is NullConnection);
            Assert.AreEqual(0, reusableComponent.Connections.Count);
        }
    }
}
