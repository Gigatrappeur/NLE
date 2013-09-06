using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE.Glossary;

namespace NLE.Grammar
{
    public class ConjugationTable
    {

        //représente une table de conjugaison (liste de conjugaison pour un temp)

        // gestion des modes ?
        public Word verbBase { get; private set; }
        public Dictionary<string, Dictionary<string, Dictionary<Person, Word>>> table;

        public ConjugationTable(Word verbBase)
        {
            this.verbBase = null;
            this.table = new Dictionary<string, Dictionary<string, Dictionary<Person, Word>>>();

            this.setBase(verbBase);
        }

        private void setBase(Word verbBase)
        {
            if (!verbBase.IsTypeOf(typeof(VerbType)))
            {
                throw new Exception(verbBase + " is not verb!");
            }

            this.verbBase = verbBase;
            this.Add(this.verbBase);
        }

        public void Add(Word verb)
        {
            if (!verb.IsTypeOf(typeof(VerbType)))
            {
                throw new Exception(verb + " is not verb!");
            }

            foreach (WordType type in verb.types)
            {
                if (type is VerbType)
                {
                    VerbType tv = (type as VerbType);

                    tv.table = this;

                    string tense = (tv.tense != null ? tv.tense : "");
                    Person person = (tv.person != null ? tv.person : new Person(0, 0, "", "", ""));

                    if (!this.table.ContainsKey(tv.mood)) this.table.Add(tv.mood, new Dictionary<string, Dictionary<Person, Word>>());
                    if (!this.table[tv.mood].ContainsKey(tense)) this.table[tv.mood].Add(tense, new Dictionary<Person, Word>());
                    
                    this.table[tv.mood][tense].Add(person, verb);

                }
            }
        }

        public void AddRange(Word[] list)
        {
            foreach (Word item in list)
            {
                this.Add(item);
            }
        }
    }
}
