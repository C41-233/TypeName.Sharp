using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeName;

namespace TypeNameTest
{
    [TestClass]
    public class MethodNameTest
    {

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("char Action1(int i)", typeof(TestA).GetMethod("Action1").GetDefinitionFullNameString());
            Assert.AreEqual("string Action2(System.Text.StringBuilder sb)", typeof(TestA).GetMethod("Action2").GetDefinitionFullNameString());
            Assert.AreEqual("string Action2(StringBuilder sb)", typeof(TestA).GetMethod("Action2").GetDefinitionNameString());
            Assert.AreEqual("string Action3(TestA a, TestA<int,int> b)", typeof(TestA).GetMethod("Action3").GetDefinitionNameString());
            Assert.AreEqual("void Func3(out int val)", typeof(TestA).GetMethod("Func3").GetDefinitionNameString());
            Assert.AreEqual("void Func4(ref int val)", typeof(TestA).GetMethod("Func4").GetDefinitionNameString());
            Assert.AreEqual("void Func5(int* val)", typeof(TestA).GetMethod("Func5").GetDefinitionNameString());
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("void Func1<T>(List<T> list)", typeof(TestA).GetMethod("Func1").GetDefinitionNameString());
            Assert.AreEqual("void Func2<T>(Dictionary<int,T> dic)", typeof(TestA).GetMethod("Func2").GetDefinitionNameString());

            Assert.AreEqual("void Func3(List<K> list)", typeof(TestA.TestC<>).GetMethod("Func3").GetDefinitionNameString());
            Assert.AreEqual("void Func3(List<int> list)", typeof(TestA.TestC<int>).GetMethod("Func3").GetDefinitionNameString());
        }

    }
}
