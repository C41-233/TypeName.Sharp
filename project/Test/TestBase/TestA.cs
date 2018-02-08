using System;
using System.Collections.Generic;
using System.Text;
using GS;

// ReSharper disable once CheckNamespace
public unsafe class TestA
{

    public class TestB
    {
    }

    public static char Action1(int i)
    {
        return default(char);
    }

    public static string Action2(StringBuilder sb)
    {
        return sb.ToString();
    }

    public static string Action3(TestA a, TestA<int, int> b)
    {
        return default(string);
    }

    public static void Func1<T>(List<T> list) { }

    public static void Func2<T>(Dictionary<int, T> dic) { }

    public static void Func3(out int val)
    {
        val = 0;
    }

    public static void Func4(ref int val)
    {
    }

    public static void Func5(int* val)
    {
        DateTime* a;
    }

    public class TestC<K>
    {
        public static void Func3(List<K> list) { }
    }

}
