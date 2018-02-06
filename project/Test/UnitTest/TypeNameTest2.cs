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
            Assert.AreEqual("TestA<T1,T2>.TestB<T3>", typeof(TestA<,>.TestB<>).GetTypeNameString());
            Assert.AreEqual("GS.TestA<T1,T2>.TestB<T3>", typeof(TestA<,>.TestB<>).GetTypeFullNameString());

            Assert.AreEqual("TestA<string,int>.TestB<DateTime>", typeof(TestA<string,int>.TestB<DateTime>).GetTypeNameString());
            Assert.AreEqual("GS.TestA<string,int>.TestB<System.DateTime>", typeof(TestA<string, int>.TestB<DateTime>).GetTypeFullNameString());

            Assert.AreEqual("TestA<MS.TestA,NS.TestA>.TestB<TestA>", typeof(TestA<MS.TestA, NS.TestA>.TestB<TestA>).GetTypeNameString());
        }

        [TestMethod]
        public void TestGenric2()
        {
            Assert.AreEqual("TestA<T1,T2>.TestC", typeof(TestA<,>.TestC).GetTypeNameString());
            Assert.AreEqual("TestA<char,double>.TestC", typeof(TestA<char, double>.TestC).GetTypeNameString());

            Assert.AreEqual("TestD.TestE<T1,T2>", typeof(TestD.TestE<,>).GetTypeNameString());
            Assert.AreEqual("TestD.TestE<long,long>", typeof(TestD.TestE<long,long>).GetTypeNameString());

            Assert.AreEqual("TestA<T1,T2>.TestC.TestF<T1>", typeof(TestA<,>.TestC.TestF<>).GetTypeNameString());
        }

        [TestMethod]
        public void TestGenric3()
        {
            Assert.AreEqual("TestInherit<T>", typeof(TestInherit<>).GetTypeNameString());
            Assert.AreEqual("List<int>", typeof(TestInherit<>).BaseType.GetTypeNameString());

            Assert.AreEqual("TestInherit<T,K>", typeof(TestInherit<,>).GetTypeNameString());
            Assert.AreEqual("List<K>", typeof(TestInherit<,>).BaseType.GetTypeNameString());
        }

    }
}
