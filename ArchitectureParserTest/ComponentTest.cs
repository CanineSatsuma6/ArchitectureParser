﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

using ArchitectureParser.Architecture.Components;
using ArchitectureParser.Architecture.Factories;
using ArchitectureParser.Architecture.Connections;

namespace ArchitectureParserTest
{
    [TestClass]
    public class ComponentTest
    {
        private static string TestComponentName        = @"Test";
        private static string DestinationComponentName = @"Destination";

        private static string OutputName = @"Output";
        private static string InputName  = @"Input";

        private static Color  Red = Color.Red;

        private static IComponent TestComponent()        => ComponentFactory.Create(TestComponentName);
        private static IComponent DestinationComponent() => ComponentFactory.Create(DestinationComponentName);

        [TestMethod]
        public void ComponentConstructor()
        {
            var component = TestComponent();

            Assert.AreEqual(TestComponentName, component.Name);
            Assert.AreEqual(0,                 component.Connections.Count);
        }

        [TestMethod]
        public void ComponentConnect()
        {
            var component   = TestComponent();
            var destination = DestinationComponent();

            var connection = component.Connect(destination, OutputName, InputName, Red);

            Assert.AreEqual(component, connection.Source);
            Assert.AreEqual(destination, connection.Destination);
            Assert.AreEqual(1, component.Connections.Count);
            Assert.AreEqual(1, component.Connections.Count);
            Assert.IsTrue(component.Connections.Contains(connection));
            Assert.IsTrue(destination.Connections.Contains(connection));
        }

        [TestMethod]
        public void ComponentConnectToNullDestination()
        {
            var component  = TestComponent();
            var connection = component.Connect(null, null, null, Red);

            Assert.IsTrue(connection is NullConnection);
            Assert.AreEqual(0, component.Connections.Count);
        }
    }
}
