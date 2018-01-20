# TypeName
C#反射字符串输出

有时候我们想输出某一个类型的符合C#语法的字符串，例如一个根据接口自动生成实现类的代码生成器，通过反射获取System.MethodInfo后，需要输出其对应的C#函数定义字符串，根据情况我们可以自己选择名称中是否需要包含namespace。

Framework提供的System.Type有三个获取字符串名称的属性/函数，分别是Name、FullName、ToString()。一般情况下，Name代表了一个类型的简单名称（不包含namespace），FullName包含了类型的完全限定名称（这不等价于包含namespace的名称）。不幸的是，部分情况下这三个属性/函数的输出结果是极其糟糕的，包括：  
1. 不能输出基元类型，例如int会被输出成System.Int32。
2. 多层级的数组类型与语法形式相反，例如int[][,]会被输出成System.Int32[,][]。
3. 泛型类型，例如List<T>会被输出成System.Collection.Generic.List&#96;1，而List<int>甚至被输出成System.Collections.Generic.List&#96;1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]。

TypeName为Type、Method、Property、Field、Parameter添加了一些扩展函数来处理所有情况，使得一个类型能够按照语法形式输出。

```C#
using TypeName;

//List<T>
Console.WriteLine(typeof(List<>).GetSourceName());

//List<int>
Console.WriteLine(typeof(List<int>).GetSourceName());

//System.Collection.Generic.List<System.DateTime?>
Console.WriteLine(typeof(List<DateTime?>).GetSourceFullName());
```

比较结果：https://c41-233.github.io/TypeName/source-name.html
