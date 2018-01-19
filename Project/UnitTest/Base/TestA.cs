using System.Collections.Generic;

// ReSharper disable once CheckNamespace
public class TestA
{

    public class TestB
    {
    }

    public static void Func1<T>(List<T> list) { }

    public static void Func2<T>(Dictionary<int, T> dic) { }

}
