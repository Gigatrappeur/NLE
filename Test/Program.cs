using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            NLE.TestClass t = new NLE.TestClass();
            int r = t.add(1, 2);

            Console.WriteLine("Résultat : " + r);

            Console.Write("Appuyer sur une touche...");
            Console.ReadKey();
        }
    }
}
