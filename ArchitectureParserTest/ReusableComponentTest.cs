using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

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

        private static Color  Red = Color.Red;

        private static IReusableComponent ReusableComponent() => ReusableComponentFactory.Create(InstanceName, BaseName);

        private static IComponent Component() => ComponentFactory.Create(ComponentName);

        [TestMethod]
        public void ReusableComponentConstructor()
        {
            var reusableComponent = ReusableComponent();

            Assert.AreEqual(InstanceName, reusableComponent.InstanceName);
            Assert.AreEqual(BaseName,     reusableComponent.BaseComponentName);
            Assert.AreEqual(0,            reusableComponent.Connections.Count);
        }

        [TestMethod]
        public void ReusableComponentConstructor2()
        {
            var reusableComponent = ReusableComponent();

            Assert.AreEqual(InstanceName, reusableComponent.InstanceName);
            Assert.AreEqual(BaseName, reusableComponent.BaseComponentName);
            Assert.AreEqual(0, reusableComponent.Connections.Count);
        }

        [TestMethod]
        public void ReusableComponentConnect()
        {
            var reusableComponent = ReusableComponent();
            var component         = Component();
            var connection        = reusableComponent.Connect(component, OutputName, InputName, Red);

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
            var reusableComponent = ReusableComponent();
            var connection = reusableComponent.Connect(null, OutputName, null, Red);

            Assert.IsTrue(connection is NullConnection);
            Assert.AreEqual(0, reusableComponent.Connections.Count);
        }
    }
}
