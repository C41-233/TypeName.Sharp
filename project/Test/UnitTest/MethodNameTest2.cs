using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestBase;
using TypeName;

namespace TypeNameTest
{
    [TestClass]
    public class MethodNameTest2
    {

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("void Dispose()", typeof(TestExplicit).GetMethods(BindingFlags.Public | BindingFlags.Instance).First(m => m.Name == "Dispose").GetDefinitionNameString());
            Assert.AreEqual("void IDisposable.Dispose()", typeof(TestExplicit).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).First(m => m.Name == "System.IDisposable.Dispose").GetDefinitionNameString());
            Assert.AreEqual("void System.IDisposable.Dispose()", typeof(TestExplicit).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).First(m => m.Name == "System.IDisposable.Dispose").GetDefinitionFullNameString());
        }

    }
}
