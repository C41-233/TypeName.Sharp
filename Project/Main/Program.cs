using System;
using GS;
using TypeName;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(TestA<,>.TestB<>).GetSourceName());
        }
    }
}
