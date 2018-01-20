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
            Assert.AreEqual("char Action1(int i)", typeof(TestA).GetMethod("Action1").GetSourceFullName());
            Assert.AreEqual("string Action2(System.Text.StringBuilder sb)", typeof(TestA).GetMethod("Action2").GetSourceFullName());
            Assert.AreEqual("string Action2(StringBuilder sb)", typeof(TestA).GetMethod("Action2").GetSourceName());
            Assert.AreEqual("string Action3(TestA a, GS.TestA<int,int> b)", typeof(TestA).GetMethod("Action3").GetSourceName());
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("void Func1<T>(List<T> list)", typeof(TestA).GetMethod("Func1").GetSourceName());
            Assert.AreEqual("void Func2<T>(Dictionary<int,T> dic)", typeof(TestA).GetMethod("Func2").GetSourceName());
            Assert.AreEqual("void Func3(List<K> list)", typeof(TestA.TestC<>).GetMethod("Func3").GetSourceName());
            Assert.AreEqual("void Func3(List<int> list)", typeof(TestA.TestC<int>).GetMethod("Func3").GetSourceName());
        }

    }
}
