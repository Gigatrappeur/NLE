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



        public static string whatTypeOfPhrase(string phrase)
        {
            
            return transform(phrase);
        }


        /*private static string[] getPhrases(string text)
        {
            return text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        }


        private static string[] getWords(string phrase)
        {
            List<string> rt = new List<string>();
            string[] words = Regex.Split(phrase, "[^a-zA-Z]+"); // problème mots composés
            foreach (var word in words)
            {
                if (word != "")
                    rt.Add(word);
            }
            return rt.ToArray(); ;
        }*/

        private static string transform(string text)
        {
            Regex regexForWord = new Regex("[a-zA-Z]+");
            Regex regexForPonctuation = new Regex(",|\\?|!|:|'|\"|;|\\.\\.\\.|\\.");

            List<PhraseItem> schema = new List<PhraseItem>();
            Match matchWord = null, matchPonctuation = null;
            int index = 0;
            while (index < text.Length)
            {
                matchWord = regexForWord.Match(text, index);
                matchPonctuation = regexForPonctuation.Match(text, index);

                if (matchWord.Value != String.Empty && (matchPonctuation.Value == String.Empty || matchWord.Index < matchPonctuation.Index))
                {
                    Word w = NLEEngine.get(matchWord.Value);
                    if (w == null) w = new Word(matchWord.Value, new UnknownType(), "Does not exist in dictionary.");
                    schema.Add(w);
                    index = matchWord.Index + matchWord.Length;
                }
                else if (matchPonctuation.Value != String.Empty)
                {
                    string typePonctuation = "";
                    switch (matchPonctuation.Value)
                    {
                        case "!": typePonctuation = "Exclamation"; break;
                        case "?": typePonctuation = "Interrogation"; break;
                        case ".": typePonctuation = "Affirmation"; break;
                        case "'": typePonctuation = "Apostrophe"; break;
                        case "\"": typePonctuation = "Guillemet"; break;
                        case ",": typePonctuation = "Virgule"; break;
                        case ":": typePonctuation = "2 points"; break;
                        case "...": typePonctuation = "points de suspension"; break;
                        case ";": typePonctuation = "point-virgule"; break;
                        default:  typePonctuation = "autre"; break;
                    }

                    schema.Add(new Punctuation(matchPonctuation.Value, typePonctuation));
                    index = matchPonctuation.Index + matchPonctuation.Length;
                }
                else
                {
                    return string.Join(" ", schema);
                }
            }

            return string.Join(" ", schema); ;
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
