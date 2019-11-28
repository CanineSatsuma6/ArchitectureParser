using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

using ArchitectureParser.Architecture.Components;

namespace ArchitectureParserTest
{
    [TestClass]
    public class CompositionTest
    {
        [TestMethod]
        public void CompositionConstructor()
        {
            var composition = new Composition("Composition");

            Assert.AreEqual("Composition", composition.Name);
            Assert.AreEqual(0,             composition.Connections.Count);
            Assert.AreEqual(0,             composition.Contents.Count);
        }

        [TestMethod]
        public void CompositionConnect()
        {
            var composition = new Composition("Composition");
            var externalComponent = new Component("Component");

            var connection = composition.Connect(externalComponent, "Output", "Input");

            Assert.AreEqual(composition, connection.Source);
            Assert.AreEqual(externalComponent, connection.Destination);
            Assert.AreEqual(1, composition.Connections.Count);
            Assert.AreEqual(1, externalComponent.Connections.Count);
            Assert.AreEqual(0, composition.Contents.Count);
            Assert.IsTrue(composition.Connections.Contains(connection));
            Assert.IsTrue(externalComponent.Connections.Contains(connection));
        }

        [TestMethod]
        public void CompositionConsolidateExternalToInternal()
        {
            var externalComponent = new Component("External");
            var internalComponent = new Component("Internal");
            var composition       = new Composition("Composition");

            composition.Contents.Add(internalComponent);

            externalComponent.Connect(composition, "Output", "CompositionInput");
            composition.Connect(internalComponent, "CompositionInput", "Input");

            composition.ConsolidateConnections();

            Assert.AreEqual(1, externalComponent.Connections.Count);
            Assert.AreEqual(1, internalComponent.Connections.Count);
            Assert.AreEqual(0, composition.Connections.Count);
            Assert.AreEqual(0, composition.Contents.Count);

            var connection = externalComponent.Connections.First();

            Assert.AreEqual(externalComponent, connection.Source);
            Assert.AreEqual(internalComponent, connection.Destination);
            Assert.AreEqual("Output", connection.SourceOutput);
            Assert.AreEqual("Input", connection.DestinationInput);
            Assert.IsTrue(externalComponent.Connections.Contains(connection));
            Assert.IsTrue(internalComponent.Connections.Contains(connection));
        }

        [TestMethod]
        public void CompositionConsolidateInternalToExternal()
        {
            var externalComponent = new Component("External");
            var internalComponent = new Component("Internal");
            var composition       = new Composition("Composition");

            composition.Contents.Add(internalComponent);

            internalComponent.Connect(composition, "Output", "CompositionOutput");
            composition.Connect(externalComponent, "CompositionOutput", "Input");

            composition.ConsolidateConnections();

            Assert.AreEqual(1, externalComponent.Connections.Count);
            Assert.AreEqual(1, internalComponent.Connections.Count);
            Assert.AreEqual(0, composition.Connections.Count);
            Assert.AreEqual(0, composition.Contents.Count);

            var connection = internalComponent.Connections.First();

            Assert.AreEqual(externalComponent, connection.Destination);
            Assert.AreEqual(internalComponent, connection.Source);
            Assert.AreEqual("Output", connection.SourceOutput);
            Assert.AreEqual("Input", connection.DestinationInput);
            Assert.IsTrue(externalComponent.Connections.Contains(connection));
            Assert.IsTrue(internalComponent.Connections.Contains(connection));
        }

        [TestMethod]
        public void CompositionConsolidateChain()
        {
            var externalBefore    = new Component("Before");
            var internalComponent = new Component("Internal");
            var externalAfter     = new Component("After");
            var composition       = new Composition("Composition");

            composition.Contents.Add(internalComponent);

            externalBefore.Connect(composition, "Output", "CompositionInput");
            composition.Connect(internalComponent, "CompositionInput", "Input");

            internalComponent.Connect(composition, "Output", "CompositionOutput");
            composition.Connect(externalAfter, "CompositionOutput", "Input");

            composition.ConsolidateConnections();

            Assert.AreEqual(1, externalBefore.Connections.Count);
            Assert.AreEqual(2, internalComponent.Connections.Count);
            Assert.AreEqual(1, externalAfter.Connections.Count);
            Assert.AreEqual(0, composition.Connections.Count);
            Assert.AreEqual(0, composition.Contents.Count);

            var connectionBefore = externalBefore.Connections.First();
            var connectionAfter  = externalAfter.Connections.First();

            Assert.AreEqual(internalComponent, connectionBefore.Destination);
            Assert.AreEqual(externalBefore, connectionBefore.Source);
            Assert.AreEqual("Output", connectionBefore.SourceOutput);
            Assert.AreEqual("Input", connectionBefore.DestinationInput);
            Assert.IsTrue(externalBefore.Connections.Contains(connectionBefore));
            Assert.IsTrue(internalComponent.Connections.Contains(connectionBefore));

            Assert.AreEqual(externalAfter, connectionAfter.Destination);
            Assert.AreEqual(internalComponent, connectionAfter.Source);
            Assert.AreEqual("Output", connectionAfter.SourceOutput);
            Assert.AreEqual("Input", connectionAfter.DestinationInput);
            Assert.IsTrue(externalAfter.Connections.Contains(connectionAfter));
            Assert.IsTrue(internalComponent.Connections.Contains(connectionAfter));
        }

        [TestMethod]
        public void CompositionConsolidatePassThrough()
        {
            var externalBefore = new Component("Before");
            var externalAfter  = new Component("After");
            var composition    = new Composition("Composition");

            externalBefore.Connect(composition, "Output", "CompositionInput");
            composition.Connect(composition, "CompositionInput", "CompositionOutput");
            composition.Connect(externalAfter, "CompositionOutput", "Input");

            composition.ConsolidateConnections();

            Assert.AreEqual(1, externalBefore.Connections.Count);
            Assert.AreEqual(1, externalAfter.Connections.Count);
            Assert.AreEqual(0, composition.Connections.Count);
            Assert.AreEqual(0, composition.Contents.Count);

            var connection = externalBefore.Connections.First();

            Assert.AreEqual(externalBefore, connection.Source);
            Assert.AreEqual(externalAfter, connection.Destination);
            Assert.AreEqual("Output", connection.SourceOutput);
            Assert.AreEqual("Input", connection.DestinationInput);
            Assert.IsTrue(externalBefore.Connections.Contains(connection));
            Assert.IsTrue(externalAfter.Connections.Contains(connection));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CompositionNoExternalInputProvider()
        {
            var internalComponent = new Component("Internal");
            var composition       = new Composition("Composition");

            composition.Contents.Add(internalComponent);
            composition.Connect(internalComponent, "CompositionInput", "Input");

            composition.ConsolidateConnections();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CompositionNoInternalInputProvider()
        {
            var externalComponent = new Component("External");
            var composition       = new Composition("Composition");

            composition.Connect(externalComponent, "CompositionOutput", "Input");

            composition.ConsolidateConnections();
        }
    }
}
