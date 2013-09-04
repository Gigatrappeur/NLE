using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE.Grammar;

namespace NLE.Glossary
{
    public class VerbType : WordType
    {
        
        // http://www.bertrandboutin.ca/Folder_151_Grammaire/B_i_modes_et_temps.htm


        // mode (indicatif, conditionnel, impératif, subjonctif, infinitif et participe)
        public string mood { get; private set; }

        // temps (futur, présent...)
        public string tense { get; private set; }

        // référence vers la table de conjugaison
        public ConjugationTable table { get; private set; } 

        // il peut correspondre à plusieurs personnes
        public Person person { get; private set; }


        public VerbType(string mood, string tense, Person person, ConjugationTable table)
        {
            this.mood = mood;
            this.tense = tense;
            this.person = person;
            this.table = table;
        }
        
        public override string ToString()
        {
            return "[verb, " + this.mood + (this.person != null ? ", " + this.person.ToString() : "") + (this.tense != null ? ", " + this.tense:"") + "]";
        }

        public override bool Equals(object obj)
        {
            return obj is VerbType && (obj as VerbType).mood == this.mood && (obj as VerbType).tense == this.tense && (obj as VerbType).person == this.person;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
