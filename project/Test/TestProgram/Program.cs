using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestBase;
using TypeName;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(TestExplicit).GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).First(m => m.Name == "System.IDisposable.Dispose").GetDefinitionNameString());
        }
    }
}
