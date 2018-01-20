# TypeName
C#反射字符串输出

有时候我们想输出某一个类型的符合C#语法的字符串，例如一个根据接口自动生成实现类的代码生成器，通过反射获取System.MethodInfo后，需要输出其对应的C#函数定义字符串，根据情况我们可以自己选择名称中是否需要包含namespace。

Framework提供的System.Type有三个获取字符串名称的属性/函数，分别是Name、FullName、ToString()。一般情况下，Name代表了一个类型的简单名称（不包含namespace），FullName包含了类型的完全限定名称（这不等价于包含namespace的名称）。不幸的是，部分情况下这三个属性/函数的输出结果是极其糟糕的，包括：  
1. 不能输出基元类型，例如int会被输出成System.Int32。
2. 多层级的数组类型与语法形式相反，例如int[][,]会被输出成System.Int32[,][]。
3. 泛型类型，例如List<T>会被输出成System.Collections.Generic.List&#96;1，而List<int>甚至被输出成System.Collections.Generic.List&#96;1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]。

具体的输出结果参见：https://c41-233.github.io/TypeName/source-name.html

TypeName为Type、Method、Property、Field、Parameter添加了一些扩展函数来处理所有情况，使得一个类型能够按照语法形式输出。

### Type
为System.Type添加了扩展方法GetSouceName和GetSourceFullName，GetSourceName用于获取不带namespace的类型语法名称（SourceName），GetSourceFullName用于获取带namespace的类型语法名称（SourceFullName）。其规则为：  
1. 如果类型是一个基本类型，那么总是返回其简化形式。基本类型指的是void、byte、char、short、ushort、int、uint、long、ulong、float、double、decimal、string。
2. 如果类型是一个可空类型，那么返回去其?形式。例如，int?、DateTime?。
3. 如果类型是一个泛型定义，那么返回其类型名称及其泛型参数的定义名称。例如，List<T>。
4. 如果类型是一个泛型类型，那么返回其类型名称及其泛型参数的类型名称。例如，List<int>。
5. SourceName的每一个部分都是不带namespace的，SourceFullName返回的每一个部分都是带namespace。例如，List<DateTime>是SourceName，那么System.Collections.Generic.List<System.DateTime>是SourceFullName。
6. SourceName中返回的任意两个部分是相同名称的不同类型，那么它们将以SourceFullName的形式返回。例如，Dictionary<NS1.A,NS2.A>的SourceName为Dictionary<NS1.A,NS2.A>，其SourceFullName为System.Collections.Generic.Dictionary<NS1.A,NS2.B>。

```C#
using TypeName;

//List<T>
Console.WriteLine(typeof(List<>).GetSourceName());

//List<int>
Console.WriteLine(typeof(List<int>).GetSourceName());

//System.Collections.Generic.List<System.DateTime?>
Console.WriteLine(typeof(List<DateTime?>).GetSourceFullName());
```

### Method
为System.MethodInfo添加了扩展方法GetSourceName和GetSourceFullName，分别用于输出一个方法不带namespace的语法定义名称和带namespace的语法定义名称，格式为`返回类型+函数名称+泛型参数定义+参数表`。SourceName和SourceFullName的规则同Type一致，它们同时作用于返回类型、泛型参数类型和参数类型。

```C#
class TestA<T>
{
	public static string Func<K>(Dictionary<T, K> dic, List<DateTime> list);
}

using TypeName;

//string Func<K>(Dictionary<T,K> dic, List<DateTime> list)
Console.WriteLine(typeof(TestA<>).GetMethod("Func").GetSourceName());


//string Func<K>(System.Collections.Generic.Dictionary<T,K> dic, System.Collections.Generic.List<System.DateTime> list)
Console.WriteLine(typeof(TestA<>).GetMethod("Func").GetSourceFullName());

//string Func<K>(Dictionary<int,K> dic, List<DateTime> list)
Console.WriteLine(typeof(TestA<int>).GetMethod("Func").GetSourceName());
```

