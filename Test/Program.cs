using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Word w1 = new Word("test");
            Word w2 = new Word("tester");
            Word w3 = new Word("mordre");
            Word w4 = new Word("testera");


            Words listWord = new Words();

            bool b1 = listWord.AddWord(w1);
            bool b2 = listWord.AddWord(w2);
            bool b3 = listWord.AddWord(w3);
            bool b4 = listWord.AddWord(w4);

            bool b5 = listWord.AddWord(w2);
            

            Console.WriteLine("ajout w1(" + w1 + ") : " + (b1 ? "reussi" : "erreur"));
            Console.WriteLine("ajout w2(" + w2 + ") : " + (b2 ? "reussi" : "erreur"));
            Console.WriteLine("ajout w3(" + w3 + ") : " + (b3 ? "reussi" : "erreur"));
            Console.WriteLine("ajout w4(" + w4 + ") : " + (b4 ? "reussi" : "erreur"));
            Console.WriteLine("re-ajout w1(" + w1 + ") : " + (b5 ? "reussi" : "erreur"));

            Word test = listWord.get("test");
            Word mords = listWord.get("mords");
            Word mordre = listWord.get("mordre");
            Console.WriteLine("on cherche 'test' : " + (test != null ? test.ToString() : "non trouve"));
            Console.WriteLine("on cherche 'mords' : " + (mords != null ? mords.ToString() : "non trouve"));
            Console.WriteLine("on cherche 'mordre' : " + (mordre != null ? mordre.ToString() : "non trouve"));

            Console.Write("Appuyer sur une touche...");
            Console.ReadKey();
        }
    }
}
