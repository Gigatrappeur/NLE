using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace NLE
{

    public class Words
    {

        // on masque le fonctionnement interne
        private class FragmentWord
        {
            private Dictionary<char, FragmentWord> childs;

            public char fragment { get; private set; }
            public Word word { get; private set; }

            public FragmentWord(char fragment)
            {
                this.childs = new Dictionary<char, FragmentWord>();
                this.fragment = fragment;
                this.word = null;
            }

            private FragmentWord search(char c)
            {
                return (this.childs.ContainsKey(c) ? this.childs[c] : null);
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
                    this.childs.Add(c, f);
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

            public override string ToString()
            {
                return this.ToString(0);
            }

            protected string ToString(int level)
            {
                String rt = this.fragment + Environment.NewLine;

                if (this.word != null)
                {
                    rt += concatene(' ', level) + this.word + Environment.NewLine;
                }

                foreach (var item in this.childs)
	            {
		            rt += concatene(' ', level) + item.Value.ToString(level + 1);
	            }

                return rt;
            }

            private string concatene(char c, int nb)
            {
                string rt = "";
                for (int i = 0; i < nb; i++)
                    rt += c;

                return rt;
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

        public bool AddWord(string w)
        {
            return this.AddWord(new Word(w));
        }

        public Word get(string w)
        {
            return this.root.get(w.ToLower());
        }

        public override string ToString()
        {
            string rt = "Words" + this.root;

            return rt;
        }
    }
}
