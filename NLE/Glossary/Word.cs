using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace NLE.Glossary
{
    public class Word : PhraseItem, IComparable<Word>
    {
        public string word { get; private set; }
        public string definition { get; private set; }


        private List<WordType> _types;
        public ReadOnlyCollection<WordType> types
        {
            get
            {
                return this._types.AsReadOnly();
            }
        }


        public Word(string word, WordType type, string definition = "")
            : this(word, new WordType[] { type }, definition)
        {
        }

        public Word(string word, WordType[] types, string definition = "")
        {
            this.word = word.ToLower();
            //this.typage = "";

            this._types = new List<WordType>();
            this._types.AddRange(types);

            this.definition = definition;
        }

        public bool IsTypeOf(Type t)
        {
            foreach (var type in this._types)
            {
                if (type.GetType() == t)
                    return true;
            }

            return false;
        }

        public T[] getTypesOf<T>()
        {
            List<T> rt = new List<T>();
            foreach (WordType item in this._types)
            {
                if (item is T) // if (item.GetType() == typeof(T))
                    rt.Add((T)item);
            }
            return rt.ToArray();
        }

        public void AddType(WordType type)
        {
            this._types.Add(type);
        }

        public void AddRangeType(IList<WordType> types)
        {
            this._types.AddRange(types);
        }

        public override string ToString()
        {
            string rt = this.word + " ";
            foreach (var key in this._types)
            {
                rt += key.ToString();
            }

            return rt;
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
