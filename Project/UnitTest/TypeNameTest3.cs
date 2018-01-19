using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeName;

namespace TypeNameTest
{

    [TestClass]
    public class TypeNameTest3
    {

        private static void AssertMethod(string expect, string expectFull, Type type, string method)
        { 
            Assert.AreEqual(expect, type.GetMethod(method).GetParameters()[0].ParameterType.GetSourceName());
            Assert.AreEqual(expectFull, type.GetMethod(method).GetParameters()[0].ParameterType.GetSourceFullName());
        }

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("T", typeof(List<>).GetGenericArguments()[0].GetSourceName());
            Assert.AreEqual("T", typeof(List<>).GetGenericArguments()[0].GetSourceFullName());
        }

        [TestMethod]
        public void Test2()
        {
            AssertMethod("List<T>", "System.Collections.Generic.List<T>", typeof(TestA), "Func1");
            AssertMethod("Dictionary<int,T>", "System.Collections.Generic.Dictionary<int,T>", typeof(TestA), "Func2");
            AssertMethod("List<K>", "System.Collections.Generic.List<K>", typeof(TestA.TestC<>), "Func3");
        }


    }
}
