﻿using System;
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
            Assert.AreEqual(expect, type.GetMethod(method).GetParameters()[0].ParameterType.GetTypeNameString());
            Assert.AreEqual(expectFull, type.GetMethod(method).GetParameters()[0].ParameterType.GetTypeFullNameString());
        }

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("T", typeof(List<>).GetGenericArguments()[0].GetTypeNameString());
            Assert.AreEqual("T", typeof(List<>).GetGenericArguments()[0].GetTypeFullNameString());
        }

        [TestMethod]
        public void Test2()
        {
            AssertMethod("List<T>", "System.Collections.Generic.List<T>", typeof(TestA), "Func1");
            AssertMethod("Dictionary<int,T>", "System.Collections.Generic.Dictionary<int,T>", typeof(TestA), "Func2");
            AssertMethod("List<K>", "System.Collections.Generic.List<K>", typeof(TestA.TestC<>), "Func3");
            AssertMethod("int", "int", typeof(TestA), "Func3");
            AssertMethod("int", "int", typeof(TestA), "Func4");
            AssertMethod("int*", "int*", typeof(TestA), "Func5");
        }


    }
}
