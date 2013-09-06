using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE.Glossary;

namespace NLE.Engine
{
    class Prediction
    {

        public static Word[] simple(LanguageDictionary dictionary, string startWord)
        {
            return dictionary.getAll(startWord);
        }


        public static Word[] contextual(LanguageDictionary dictionary, string phrase, string startWord)
        {

            // retrouver ou est situé le startWord dans la phrase
            // cela devrait permettre de déterminer le type du mot attendu (à l'aide des règles d'inférences)

            return new Word[] {};
        }
    }
}
