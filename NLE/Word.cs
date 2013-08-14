using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE
{
    public class Word
    {
        public string word { get; private set; }

        // stocker des attributs ? (verbe, nom...)

        public Word(string word)
        {
            this.word = word;
        }

        public override string ToString()
        {
            return "Word [" + this.word + "]";
        }
    }
}
