using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Linq;

using ArchitectureParser.Architecture.Components;
using ArchitectureParser.Architecture.Factories;
using ArchitectureParser.Architecture.Exceptions;
using ArchitectureParser.Architecture.Compositions;

namespace ArchitectureParserTest
{
    [TestClass]
    public class CompositionTest
    {
        private static string CompositionName       = @"Composition";
        private static string ExternalBeforeName    = @"Before";
        private static string ExternalAfterName     = @"After";
        private static string InternalComponentName = @"Internal";

        private static string OutputName            = @"Output";
        private static string InputName             = @"Input";
        private static string CompositionOutputName = @"CompositionOutput";
        private static string CompositionInputName  = @"CompositionInput";

        private static Color  Red = Color.Red;

        public static IComposition Composition()       => CompositionFactory.Create(CompositionName);
        public static IComponent   ExternalBefore()    => ComponentFactory.Create(ExternalBeforeName);
        public static IComponent   ExternalAfter()     => ComponentFactory.Create(ExternalAfterName);
        public static IComponent   InternalComponent() => ComponentFactory.Create(InternalComponentName);

        [TestMethod]
        public void CompositionConstructor()
        {
            var composition = Composition();

            Assert.AreEqual(CompositionName, composition.Name);
            Assert.AreEqual(0,             composition.Connections.Count);
            Assert.AreEqual(0,             composition.Contents.Count);
        }

        [TestMethod]
        public void CompositionConnect()
        {
            var composition       = Composition();
            var externalComponent = ExternalBefore();

            var connection = composition.Connect(externalComponent, OutputName, InputName, Red);

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
            var externalComponent = ExternalBefore();
            var internalComponent = InternalComponent();
            var composition       = Composition();

            composition.Contents.Add(internalComponent);

            externalComponent.Connect(composition, OutputName, CompositionInputName, Red);
            composition.Connect(internalComponent, CompositionInputName, InputName, Red);

            composition.ConsolidateConnections();

            Assert.AreEqual(1, externalComponent.Connections.Count);
            Assert.AreEqual(1, internalComponent.Connections.Count);
            Assert.AreEqual(0, composition.Connections.Count);
            Assert.AreEqual(0, composition.Contents.Count);

            var connection = externalComponent.Connections.First();

            Assert.AreEqual(externalComponent, connection.Source);
            Assert.AreEqual(internalComponent, connection.Destination);
            Assert.AreEqual(OutputName, connection.SourceOutput);
            Assert.AreEqual(InputName, connection.DestinationInput);
            Assert.IsTrue(externalComponent.Connections.Contains(connection));
            Assert.IsTrue(internalComponent.Connections.Contains(connection));
        }

        [TestMethod]
        public void CompositionConsolidateInternalToExternal()
        {
            var externalComponent = ExternalAfter();
            var internalComponent = InternalComponent();
            var composition       = Composition();

            composition.Contents.Add(internalComponent);

            internalComponent.Connect(composition, OutputName, CompositionOutputName, Red);
            composition.Connect(externalComponent, CompositionOutputName, InputName, Red);

            composition.ConsolidateConnections();

            Assert.AreEqual(1, externalComponent.Connections.Count);
            Assert.AreEqual(1, internalComponent.Connections.Count);
            Assert.AreEqual(0, composition.Connections.Count);
            Assert.AreEqual(0, composition.Contents.Count);

            var connection = internalComponent.Connections.First();

            Assert.AreEqual(externalComponent, connection.Destination);
            Assert.AreEqual(internalComponent, connection.Source);
            Assert.AreEqual(OutputName, connection.SourceOutput);
            Assert.AreEqual(InputName, connection.DestinationInput);
            Assert.IsTrue(externalComponent.Connections.Contains(connection));
            Assert.IsTrue(internalComponent.Connections.Contains(connection));
        }

        [TestMethod]
        public void CompositionConsolidateChain()
        {
            var externalBefore    = ExternalBefore();
            var internalComponent = InternalComponent();
            var externalAfter     = ExternalAfter();
            var composition       = Composition();

            composition.Contents.Add(internalComponent);

            externalBefore.Connect(composition, OutputName, CompositionInputName, Red);
            composition.Connect(internalComponent, CompositionInputName, InputName, Red);

            internalComponent.Connect(composition, OutputName, CompositionOutputName, Red);
            composition.Connect(externalAfter, CompositionOutputName, InputName, Red);

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
            Assert.AreEqual(OutputName, connectionBefore.SourceOutput);
            Assert.AreEqual(InputName, connectionBefore.DestinationInput);
            Assert.IsTrue(externalBefore.Connections.Contains(connectionBefore));
            Assert.IsTrue(internalComponent.Connections.Contains(connectionBefore));

            Assert.AreEqual(externalAfter, connectionAfter.Destination);
            Assert.AreEqual(internalComponent, connectionAfter.Source);
            Assert.AreEqual(OutputName, connectionAfter.SourceOutput);
            Assert.AreEqual(InputName, connectionAfter.DestinationInput);
            Assert.IsTrue(externalAfter.Connections.Contains(connectionAfter));
            Assert.IsTrue(internalComponent.Connections.Contains(connectionAfter));
        }

        [TestMethod]
        public void CompositionConsolidatePassThrough()
        {
            var externalBefore = ExternalBefore();
            var externalAfter  = ExternalAfter();
            var composition    = Composition();

            externalBefore.Connect(composition, OutputName, CompositionInputName, Red);
            composition.Connect(composition, CompositionInputName, CompositionOutputName, Red);
            composition.Connect(externalAfter, CompositionOutputName, InputName, Red);

            composition.ConsolidateConnections();

            Assert.AreEqual(1, externalBefore.Connections.Count);
            Assert.AreEqual(1, externalAfter.Connections.Count);
            Assert.AreEqual(0, composition.Connections.Count);
            Assert.AreEqual(0, composition.Contents.Count);

            var connection = externalBefore.Connections.First();

            Assert.AreEqual(externalBefore, connection.Source);
            Assert.AreEqual(externalAfter, connection.Destination);
            Assert.AreEqual(OutputName, connection.SourceOutput);
            Assert.AreEqual(InputName, connection.DestinationInput);
            Assert.IsTrue(externalBefore.Connections.Contains(connection));
            Assert.IsTrue(externalAfter.Connections.Contains(connection));
        }

        [TestMethod]
        [ExpectedException(typeof(NoProvidingSourceException))]
        public void CompositionNoExternalInputProvider()
        {
            var internalComponent = InternalComponent();
            var composition       = Composition();

            composition.Contents.Add(internalComponent);
            composition.Connect(internalComponent, CompositionInputName, InputName, Red);

            composition.ConsolidateConnections();
        }

        [TestMethod]
        [ExpectedException(typeof(NoProvidingSourceException))]
        public void CompositionNoInternalInputProvider()
        {
            var externalComponent = ExternalAfter();
            var composition       = Composition();

            composition.Connect(externalComponent, CompositionOutputName, InputName, Red);

            composition.ConsolidateConnections();
        }
    }
}
