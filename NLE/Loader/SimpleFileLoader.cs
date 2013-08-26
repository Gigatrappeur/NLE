using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NLE.Glossary;
using NLE.Engine;

namespace NLE.Loader
{
    class SimpleFileLoader : ILoader
    {
        private string filename = null;

        public SimpleFileLoader(string filename)
        {
            if (!File.Exists(filename)) throw new Exception("File \"" + filename + "\" not found!");

            this.filename = filename;
        }

        bool ILoader.Load(Words dico)
        {
            if (this.filename == null) return false;

            string[] lines = File.ReadAllLines(this.filename);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] word = lines[i].ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (word.Length == 0) continue; // ligne vide

                if (word.Length == 1)
                {
                    dico.AddWord(new UnknownWord(word[0]));
                }
                else
                {
                    switch (word[1])
                    {
                        case "nom":
                            dico.AddWord(new Noun(word[0]));
                            break;
                        case "verbe":

                            if (word.Length == 3 && word[2] == "infinitif")
                            {
                                dico.AddWord(new InfinitiveVerb(word[0]));
                            }
                            else if (word.Length == 6 && word[2] == "conjuguer")
                            {
                                InfinitiveVerb infinitif = null;
                                Word maybeInfinitif = dico.get(word[4]);
                                if (maybeInfinitif is InfinitiveVerb)
                                    infinitif = (InfinitiveVerb) maybeInfinitif;

                                dico.AddWord(new ConjugatedVerb(word[0], word[3], infinitif, new string[] {word[5]}));
                            }
                            else
                            {
                                // unknown type verb
                                dico.AddWord(new Verb(word[0]));
                            }

                            break;
                        case "adjectif":
                            dico.AddWord(new Adjective(word[0]));
                            break;
                        default:
                            dico.AddWord(new UnknownWord(word[0]));
                            break;
                    }
                }

            }

            return true; // dico chargé
        }

        bool ILoader.UnLoad()
        {
            return true;
        }
    }
}
