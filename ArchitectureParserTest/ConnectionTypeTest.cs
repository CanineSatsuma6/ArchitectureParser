using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

using ArchitectureParser.Architecture.Connections.Types;
using ArchitectureParser.Architecture.Factories;

namespace ArchitectureParserTest
{
    [TestClass]
    public class ConnectionTypeTest
    {
        private static Color Red   = Color.Red;
        private static Color Green = Color.Green;
        private static Color Blue  = Color.Blue;

        private static IConnectionType Integer() => ConnectionTypeFactory.GetType(Red);
        private static IConnectionType Boolean() => ConnectionTypeFactory.GetType(Green);
        private static IConnectionType Double()  => ConnectionTypeFactory.GetType(Blue);

        [TestMethod]
        public void ConnectionTypeTestConstructorInteger()
        {
            var connectionType = Integer();

            Assert.AreEqual(ConnectionType.Integer, connectionType);
        }

        [TestMethod]
        public void ConnectionTypeTestConstructorBoolean()
        {
            var connectionType = Boolean();

            Assert.AreEqual(ConnectionType.Boolean, connectionType);
        }

        [TestMethod]
        public void ConnectionTypeTestConstructorDouble()
        {
            var connectionType = Double();

            Assert.AreEqual(ConnectionType.Double, connectionType);
        }

        [TestMethod]
        public void ConnectionTypeTestConstructorComplex()
        {
            var newConnectionType = new ConnectionType("DriveCommand", "DriveCommand", "new DriveCommand()", "new DriveCommand()");
            ConnectionTypeFactory.RegisterType(Color.Cyan, newConnectionType);

            var connectionType = ConnectionTypeFactory.GetType(Color.Cyan);
           
            Assert.AreEqual(newConnectionType, connectionType);
        }
    }
}
