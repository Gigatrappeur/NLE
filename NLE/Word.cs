using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public abstract class Word : IComparable<Word>
    {
        public string word { get; private set; }
        public string typage { get; private set; }


        public Word(string word)
        {
            this.word = word.ToLower();
            this.typage = "";
        }

        protected void addTypage(string t)
        {
            this.typage += (this.typage != "" ? ", " : "") + t;
        }

        public override string ToString()
        {
            return this.word + " [" + this.typage + "]";
        }


        /// <summary>
        /// Implementation de IComparable pour permettre de trier des Word
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Word other)
        {
            return word.CompareTo(other.word);
        }

        
    }
}
