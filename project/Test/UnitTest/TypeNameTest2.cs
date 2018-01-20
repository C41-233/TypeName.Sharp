using System;
using GS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestBase;
using TypeName;

namespace TypeNameTest
{

    [TestClass]
    public class TypeNameTest2
    {

        [TestMethod]
        public void TestGenric1()
        {
            Assert.AreEqual("TestA<T1,T2>.TestB<T3>", typeof(TestA<,>.TestB<>).GetSourceName());
            Assert.AreEqual("GS.TestA<T1,T2>.TestB<T3>", typeof(TestA<,>.TestB<>).GetSourceFullName());

            Assert.AreEqual("TestA<string,int>.TestB<DateTime>", typeof(TestA<string,int>.TestB<DateTime>).GetSourceName());
            Assert.AreEqual("GS.TestA<string,int>.TestB<System.DateTime>", typeof(TestA<string, int>.TestB<DateTime>).GetSourceFullName());

            Assert.AreEqual("GS.TestA<MS.TestA,NS.TestA>.TestB<TestA>", typeof(TestA<MS.TestA, NS.TestA>.TestB<TestA>).GetSourceName());
        }

        [TestMethod]
        public void TestGenric2()
        {
            Assert.AreEqual("TestA<T1,T2>.TestC", typeof(TestA<,>.TestC).GetSourceName());
            Assert.AreEqual("TestA<char,double>.TestC", typeof(TestA<char, double>.TestC).GetSourceName());

            Assert.AreEqual("TestD.TestE<T1,T2>", typeof(TestD.TestE<,>).GetSourceName());
            Assert.AreEqual("TestD.TestE<long,long>", typeof(TestD.TestE<long,long>).GetSourceName());

            Assert.AreEqual("TestA<T1,T2>.TestC.TestF<T1>", typeof(TestA<,>.TestC.TestF<>).GetSourceName());
        }

        [TestMethod]
        public void TestGenric3()
        {
            Assert.AreEqual("TestInherit<T>", typeof(TestInherit<>).GetSourceName());
            Assert.AreEqual("List<int>", typeof(TestInherit<>).BaseType.GetSourceName());

            Assert.AreEqual("TestInherit<T,K>", typeof(TestInherit<,>).GetSourceName());
            Assert.AreEqual("List<K>", typeof(TestInherit<,>).BaseType.GetSourceName());
        }

    }
}
