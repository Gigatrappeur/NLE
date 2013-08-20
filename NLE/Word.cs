﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE
{
    public class Word : IComparable<Word>
    {
        public string word { get; private set; }

        // stocker des attributs ? (verbe, nom...)

        public Word(string word)
        {
            this.word = word.ToLower();
        }

        public override string ToString()
        {
            return "Word [" + this.word + "]";
        }


        /// <summary>
        /// Implementation de IComparable pour permettre de trier des Word
        /// </summary>
        public int CompareTo(Word other)
        {
            return word.CompareTo(other.word);
        }

        
    }
}
