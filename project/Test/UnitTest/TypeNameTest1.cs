using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeName;

namespace TypeNameTest
{
    [TestClass]
    public class TypeNameTest1
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("int", typeof(int).GetTypeNameString());
            Assert.AreEqual("int", typeof(int).GetTypeFullNameString());

            Assert.AreEqual("string", typeof(string).GetTypeNameString());
            Assert.AreEqual("string", typeof(string).GetTypeFullNameString());

            Assert.AreEqual("int?", typeof(int?).GetTypeNameString());
            Assert.AreEqual("int?", typeof(int?).GetTypeFullNameString());
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("int[]", typeof(int[]).GetTypeNameString());
            Assert.AreEqual("int[]", typeof(int[]).GetTypeFullNameString());

            Assert.AreEqual("int[,]", typeof(int[,]).GetTypeFullNameString());
            Assert.AreEqual("int[,]", typeof(int[,]).GetTypeFullNameString());

            Assert.AreEqual("uint[][,]", typeof(uint[][,]).GetTypeNameString());
            Assert.AreEqual("uint[,][]", typeof(uint[,][]).GetTypeNameString());

            Assert.AreEqual("decimal[][]", typeof(decimal[][]).GetTypeNameString());
            Assert.AreEqual("float[][]", typeof(float[][]).GetTypeNameString());

            Assert.AreEqual("decimal[][]", typeof(decimal[][]).GetTypeNameString());
            Assert.AreEqual("float[][]", typeof(float[][]).GetTypeNameString());

            Assert.AreEqual("char?[][][,]", typeof(char?[][][,]).GetTypeFullNameString());
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("IDisposable", typeof(IDisposable).GetTypeNameString());
            Assert.AreEqual("System.IDisposable", typeof(IDisposable).GetTypeFullNameString());

            Assert.AreEqual("DateTime", typeof(DateTime).GetTypeNameString());
            Assert.AreEqual("System.DateTime", typeof(DateTime).GetTypeFullNameString());

            Assert.AreEqual("DateTime?", typeof(DateTime?).GetTypeNameString());
            Assert.AreEqual("System.DateTime?", typeof(DateTime?).GetTypeFullNameString());

            Assert.AreEqual("DateTime?[]", typeof(DateTime?[]).GetTypeNameString());
            Assert.AreEqual("System.DateTime?[]", typeof(DateTime?[]).GetTypeFullNameString());
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual("List<T>", typeof(List<>).GetTypeNameString());
            Assert.AreEqual("System.Collections.Generic.List<T>", typeof(List<>).GetTypeFullNameString());

            Assert.AreEqual("List<int>", typeof(List<int>).GetTypeNameString());
            Assert.AreEqual("System.Collections.Generic.List<int>", typeof(List<int>).GetTypeFullNameString());

            Assert.AreEqual("List<DateTime>", typeof(List<DateTime>).GetTypeNameString());
            Assert.AreEqual("System.Collections.Generic.List<System.DateTime>", typeof(List<DateTime>).GetTypeFullNameString());

            Assert.AreEqual("List<List<int>>", typeof(List<List<int>>).GetTypeNameString());
            Assert.AreEqual("System.Collections.Generic.List<System.Collections.Generic.List<int>>", typeof(List<List<int>>).GetTypeFullNameString());
        }

        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual("Dictionary<TKey,TValue>", typeof(Dictionary<,>).GetTypeNameString());
            Assert.AreEqual("System.Collections.Generic.Dictionary<TKey,TValue>", typeof(Dictionary<,>).GetTypeFullNameString());

            Assert.AreEqual("Dictionary<int,string>", typeof(Dictionary<int, string>).GetTypeNameString());
            Assert.AreEqual("System.Collections.Generic.Dictionary<int,string>", typeof(Dictionary<int, string>).GetTypeFullNameString());

            Assert.AreEqual("Dictionary<byte,DateTime>", typeof(Dictionary<byte, DateTime>).GetTypeNameString());
            Assert.AreEqual("System.Collections.Generic.Dictionary<byte,System.DateTime>", typeof(Dictionary<byte, DateTime>).GetTypeFullNameString());

            Assert.AreEqual("Dictionary<List<int>,Dictionary<List<string>,DateTime>>", typeof(Dictionary<List<int>, Dictionary<List<string>, DateTime>>).GetTypeNameString());
            Assert.AreEqual("System.Collections.Generic.Dictionary<System.Collections.Generic.List<int>,System.Collections.Generic.Dictionary<System.Collections.Generic.List<string>,System.DateTime>>", typeof(Dictionary<List<int>, Dictionary<List<string>, DateTime>>).GetTypeFullNameString());
        }

        [TestMethod]
        public void Test7()
        {
            Assert.AreEqual("TestA", typeof(TestA).GetTypeNameString());
            Assert.AreEqual("TestA", typeof(TestA).GetTypeFullNameString());

            Assert.AreEqual("TestA.TestB", typeof(TestA.TestB).GetTypeNameString());
            Assert.AreEqual("TestA.TestB", typeof(TestA.TestB).GetTypeFullNameString());

            Assert.AreEqual("TestA.TestB", typeof(NS.TestA.TestB).GetTypeNameString());
            Assert.AreEqual("NS.TestA.TestB", typeof(NS.TestA.TestB).GetTypeFullNameString());

            Assert.AreEqual("Dictionary<TestA,NS.TestA>", typeof(Dictionary<TestA, NS.TestA>).GetTypeNameString());
            Assert.AreEqual("System.Collections.Generic.Dictionary<TestA,NS.TestA>", typeof(Dictionary<TestA, NS.TestA>).GetTypeFullNameString());

            Assert.AreEqual("Dictionary<NS.TestA,MS.TestA>", typeof(Dictionary<NS.TestA, MS.TestA>).GetTypeNameString());
        }

    }
}
