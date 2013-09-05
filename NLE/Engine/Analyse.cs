using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using NLE.Glossary;
using System.Text.RegularExpressions;

namespace NLE.Engine
{
    class Analyse
    {
        /// <summary>
        /// Analyse lexicale
        /// </summary>
        /// <param name="text"></param>
        public static Word[] lexical(string text)
        {
            string[] words = Regex.Split(text, "[^a-zA-Z]+");
            return getWords(words); ;
        }


        private static Word[] getWords(string[] words)
        {
            List<Word> rt = new List<Word>();
            foreach (var word in words)
            {
                if (word != "")
                {
                    Word w = NLEEngine.get(word);
                    if (w == null) w = new Word(word, new UnknownType(), "Does not exist in dictionary.");
                    rt.Add(w);
                }
            }
            return rt.ToArray();
        }
    }
}
