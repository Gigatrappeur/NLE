using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE
{
    static class Utils
    {
        public static Dictionary<string, string> translations = null;

        public static bool hasTraslation(string word)
        {
            return translations.ContainsKey(word.ToLower());
        }

        public static string translate(string word)
        {
            return hasTraslation(word) ? translations[word.ToLower()] : word.ToLower();
        }
    }
}
