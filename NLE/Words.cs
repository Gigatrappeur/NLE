using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace NLE
{
    /*
     * un moyen d'optimiser cette arbre serai de passer par un arbre binaire
     */

    public class Words
    {

        // on masque le fonctionnement interne
        private class FragmentWord
        {
            private Collection<FragmentWord> childs;
            public char fragment { get; private set; }
            public Word word { get; private set; }

            public FragmentWord(char fragment)
            {
                this.childs = new Collection<FragmentWord>();
                this.fragment = fragment;
                this.word = null;
            }

            private FragmentWord search(char c)
            {
                int i = 0;
                while (i < this.childs.Count && this.childs[i].fragment != c)
                    i++;

                if (i < this.childs.Count)
                    return this.childs[i];

                return null;
            }

            public Word get(string w)
            {
                FragmentWord fw = this.search(w[0]);
                if (fw == null)
                    return null; // mot pas trouvé

                if (w.Length == 1) // on est arrivé à la fin du mot
                    return fw.word;
                
                return fw.get(w.Substring(1)); // on continu de chercher
            }

            public bool AddFragment(Word w, string substr)
            {
                char c = substr[0];

                FragmentWord f = this.search(c);
                if (f == null)
                {
                    f = new FragmentWord(c);
                    this.childs.Add(f);
                }

                if (substr.Length > 1)
                {
                    return f.AddFragment(w, substr.Substring(1)); // on propage l'ajout
                }
                else if (substr.Length == 1 && f.word == null)
                {
                    f.word = w;
                    return true; // on a ajouté le mot
                }

                return false; // on a rien ajouté
            }
        }


        private FragmentWord root;

        public Words()
        {
            this.root = new FragmentWord(' ');
        }

        public bool AddWord(Word w)
        {
            //return FragmentWord.addWordToTree(w, this.root);
            return this.root.AddFragment(w, w.word);
        }

        public Word get(string w)
        {
            return this.root.get(w);
        }

        public override string ToString()
        {
            string rt = "Words " + this.root;

            return rt;
        }
    }
}
