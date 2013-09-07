using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public class Punctuation : PhraseItem
    {
        public string punctuation { get; private set; }

        public string type { get; private set; }
        // nom ?
        // signification ?

        public Punctuation(string p, string type)
        {
            this.punctuation = p;
            this.type = type;
        }

        public override string ToString()
        {
            return this.punctuation + " [" + this.type + "]";
        }
    }
}
