﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE;
using NLE.Glossary;
using NLE.Engine;
using NLE.Loader;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Test2();

            Console.Write("Appuyer sur une touche...");
            Console.ReadKey();
        }


        static void Test1()
        {

            Word w1 = new Noun("test");
            InfinitiveVerb w2 = new InfinitiveVerb("tester");
            Word w3 = new InfinitiveVerb("mordre");
            Word w4 = new ConjugatedVerb("testera", "futur simple", w2, "3ieme personne singulier");


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

            Console.WriteLine(Environment.NewLine + "Distance Levenshtein entre 'test' et 'text' : " + Algorithms.LevenshteinDistance("test", "text"));


            listWord.AddWord(new Noun("atome"));
            listWord.AddWord(new Adjective("atomique"));
            listWord.AddWord(new Adjective("atone"));

            Console.WriteLine(Environment.NewLine + "Arbre :" + Environment.NewLine + listWord);

            Console.WriteLine(Environment.NewLine + "Liste des mots contenu dans notre dictionnaire :");

            Word[] words = listWord.getAll();
            Array.Sort(words);
            Console.WriteLine(Utils.ToString(words));


            Console.WriteLine(Environment.NewLine + "Liste de mot prédit à partir de 'test':" + Environment.NewLine + Utils.ToString(Prediction.simple(listWord, "test")));
        }

        static void Test2()
        {
            SimpleFileLoader loader = new SimpleFileLoader(@"..\..\..\Data\TestData.txt");
            Words listWord = new Words(loader);
            listWord.load();

            Console.WriteLine(Environment.NewLine + "Arbre :" + Environment.NewLine + listWord);
        }
    }
}
