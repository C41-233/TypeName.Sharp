using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
// ReSharper disable ConvertNullableToShortForm

// ReSharper disable BuiltInTypeReferenceStyle
namespace DocBuilder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            {
                var tyname = new TypeNameOutput();
                tyname.Add<int>("int");
                tyname.Add<Int32>("Int32");
                tyname.Add<byte>("byte");
                tyname.Add<Byte>("Byte");
                tyname.Add<string>("string");
                tyname.Add<String>("String");
                tyname.Add("void", typeof(void));
                tyname.Save($"{args[0]}/source-name-1.json");
            }

            {
                var tyname = new TypeNameOutput();
                tyname.Add<DateTime>("DateTime");
                tyname.Add<StringBuilder>("StringBuilder");
                tyname.Add<BindingFlags>("BindingFlags");
                tyname.Add<FlagsAttribute>("FlagsAttribute");
                tyname.Save($"{args[0]}/source-name-2.json");
            }

            {
                var tyname = new TypeNameOutput();
                tyname.Add<float?>("float?");
                tyname.Add<Single?>("Single?");
                tyname.Add<Nullable<float>>("Nullable<float>");
                tyname.Add<Nullable<Single>>("Nullable<Single>");
                tyname.Add<DateTime?>("DateTime?");
                tyname.Add<Nullable<DateTime>>("Nullable<DateTime>");
                tyname.Save($"{args[0]}/source-name-3.json");
            }

            {
                var tyname = new TypeNameOutput();
                tyname.Add<int[]>("int[]");
                tyname.Add<uint[][]>("uint[][]");
                tyname.Add<string[,][]>("string[,][]");
                tyname.Add<DateTime[][,]>("DateTime[][,]");
                tyname.Add<decimal?[][][]>("decimal?[][][]");
                tyname.Add<DateTime?[][][,]>("DateTime?[][][,]");
                tyname.Save($"{args[0]}/source-name-4.json");
            }

            {
                var tyname = new TypeNameOutput();
                tyname.Add("List<>", typeof(List<>));
                tyname.Add("List<int>", typeof(List<int>));
                tyname.Add("List<DateTime?>", typeof(List<DateTime?>));
                tyname.Add("Dictionary<,>", typeof(Dictionary<,>));
                tyname.Add("Dictionary<double, IDisposable>", typeof(Dictionary<double, IDisposable>));
                tyname.Add("Dictionary<List<int>, StringBuilder[,]>", typeof(Dictionary<List<int>, StringBuilder[,]>));
                tyname.Save($"{args[0]}/source-name-5.json");
            }

            {
                var tyname = new TypeNameOutput();
                tyname.Add("Dictionary<,>.KeyCollection", typeof(Dictionary<,>.KeyCollection));
                tyname.Add("Dictionary<long, StringBuilder>.KeyCollection", typeof(Dictionary<long,StringBuilder>.KeyCollection));
                tyname.Save($"{args[0]}/source-name-6.json");
            }
        }

    }
}
