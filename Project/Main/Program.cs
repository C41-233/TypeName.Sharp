using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using GS;
using TypeName;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(TestA<char, double>.TestC).GetSourceName());
        }
    }
}
