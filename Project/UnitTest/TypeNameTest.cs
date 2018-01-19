using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeName;

namespace TypeNameTest
{
    [TestClass]
    public class TypeNameTest
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("int", typeof(int).GetSourceName());
            Assert.AreEqual("int", typeof(int).GetSourceFullName());

            Assert.AreEqual("string", typeof(string).GetSourceName());
            Assert.AreEqual("string", typeof(string).GetSourceFullName());

            Assert.AreEqual("int?", typeof(int?).GetSourceName());
            Assert.AreEqual("int?", typeof(int?).GetSourceFullName());
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("int[]", typeof(int[]).GetSourceName());
            Assert.AreEqual("int[]", typeof(int[]).GetSourceFullName());

            Assert.AreEqual("int[,]", typeof(int[,]).GetSourceName());
            Assert.AreEqual("int[,]", typeof(int[,]).GetSourceFullName());

            Assert.AreEqual("uint[][,]", typeof(uint[][,]).GetSourceName());
            Assert.AreEqual("uint[,][]", typeof(uint[,][]).GetSourceName());

            Assert.AreEqual("decimal[][]", typeof(decimal[][]).GetSourceFullName());
            Assert.AreEqual("float[][]", typeof(float[][]).GetSourceName());

            Assert.AreEqual("decimal[][]", typeof(decimal[][]).GetSourceFullName());
            Assert.AreEqual("float[][]", typeof(float[][]).GetSourceName());

            Assert.AreEqual("char?[][][,]", typeof(char?[][][,]).GetSourceFullName());
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("IDisposable", typeof(IDisposable).GetSourceName());
            Assert.AreEqual("System.IDisposable", typeof(IDisposable).GetSourceFullName());

            Assert.AreEqual("DateTime", typeof(DateTime).GetSourceName());
            Assert.AreEqual("System.DateTime", typeof(DateTime).GetSourceFullName());

            Assert.AreEqual("DateTime?", typeof(DateTime?).GetSourceName());
            Assert.AreEqual("System.DateTime?", typeof(DateTime?).GetSourceFullName());

            Assert.AreEqual("DateTime?[]", typeof(DateTime?[]).GetSourceName());
            Assert.AreEqual("System.DateTime?[]", typeof(DateTime?[]).GetSourceFullName());
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual("List<T>", typeof(List<>).GetSourceName());
            Assert.AreEqual("System.Collections.Generic.List<T>", typeof(List<>).GetSourceFullName());

            Assert.AreEqual("List<int>", typeof(List<int>).GetSourceName());
            Assert.AreEqual("System.Collections.Generic.List<int>", typeof(List<int>).GetSourceFullName());

            Assert.AreEqual("List<DateTime>", typeof(List<DateTime>).GetSourceName());
            Assert.AreEqual("System.Collections.Generic.List<System.DateTime>", typeof(List<DateTime>).GetSourceFullName());

            Assert.AreEqual("List<List<int>>", typeof(List<List<int>>).GetSourceName());
            Assert.AreEqual("System.Collections.Generic.List<System.Collections.Generic.List<int>>", typeof(List<List<int>>).GetSourceFullName());
        }

        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual("Dictionary<TKey,TValue>", typeof(Dictionary<,>).GetSourceName());
            Assert.AreEqual("System.Collections.Generic.Dictionary<TKey,TValue>", typeof(Dictionary<,>).GetSourceFullName());

            Assert.AreEqual("Dictionary<int,string>", typeof(Dictionary<int, string>).GetSourceName());
            Assert.AreEqual("System.Collections.Generic.Dictionary<int,string>", typeof(Dictionary<int, string>).GetSourceFullName());

            Assert.AreEqual("Dictionary<byte,DateTime>", typeof(Dictionary<byte, DateTime>).GetSourceName());
            Assert.AreEqual("System.Collections.Generic.Dictionary<byte,System.DateTime>", typeof(Dictionary<byte, DateTime>).GetSourceFullName());

            Assert.AreEqual("Dictionary<List<int>,Dictionary<List<string>,DateTime>>", typeof(Dictionary<List<int>, Dictionary<List<string>, DateTime>>).GetSourceName());
            Assert.AreEqual("System.Collections.Generic.Dictionary<System.Collections.Generic.List<int>,System.Collections.Generic.Dictionary<System.Collections.Generic.List<string>,System.DateTime>>", typeof(Dictionary<List<int>, Dictionary<List<string>, DateTime>>).GetSourceFullName());
        }

        [TestMethod]
        public void Test6()
        {
            Assert.AreEqual("T", typeof(List<>).GetGenericArguments()[0].GetSourceName());
            Assert.AreEqual("T", typeof(List<>).GetGenericArguments()[0].GetSourceFullName());

            Assert.AreEqual("List<T>", typeof(TestA).GetMethod("Func1").GetParameters()[0].ParameterType.GetSourceName());
            Assert.AreEqual("System.Collections.Generic.List<T>", typeof(TestA).GetMethod("Func1").GetParameters()[0].ParameterType.GetSourceFullName());

            Assert.AreEqual("Dictionary<int,T>", typeof(TestA).GetMethod("Func2").GetParameters()[0].ParameterType.GetSourceName());
            Assert.AreEqual("System.Collections.Generic.Dictionary<int,T>", typeof(TestA).GetMethod("Func2").GetParameters()[0].ParameterType.GetSourceFullName());
        }

        [TestMethod]
        public void Test7()
        {
            Assert.AreEqual("TestA", typeof(TestA).GetSourceName());
            Assert.AreEqual("TestA", typeof(TestA).GetSourceFullName());

            Assert.AreEqual("TestA.TestB", typeof(TestA.TestB).GetSourceName());
            Assert.AreEqual("TestA.TestB", typeof(TestA.TestB).GetSourceFullName());

            Assert.AreEqual("TestA.TestB", typeof(NS.TestA.TestB).GetSourceName());
            Assert.AreEqual("NS.TestA.TestB", typeof(NS.TestA.TestB).GetSourceFullName());

            Assert.AreEqual("Dictionary<TestA,NS.TestA>", typeof(Dictionary<TestA, NS.TestA>).GetSourceName());
            Assert.AreEqual("System.Collections.Generic.Dictionary<TestA,NS.TestA>", typeof(Dictionary<TestA, NS.TestA>).GetSourceFullName());

            Assert.AreEqual("Dictionary<NS.TestA,MS.TestA>", typeof(Dictionary<NS.TestA, MS.TestA>).GetSourceName());
        }

    }
}
