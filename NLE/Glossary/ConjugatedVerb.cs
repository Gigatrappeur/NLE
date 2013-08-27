using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE.Engine;

namespace NLE.Glossary
{
    public class ConjugatedVerb : Verb
    {
        // temps (futur, présent...)
        public string tense { get; private set; }

        // référence vers le verbe à l'infinitif
        public InfinitiveVerb infinitive { get; private set; } 

        // il peut correspondre à plusieurs personnes
        public Person[] persons { get; private set; }


        public ConjugatedVerb(string v, string tense, InfinitiveVerb infinitive, Person[] persons)
            : base(v)
        {
            this.addTypage("Conjugué");

            this.tense = tense;
            this.infinitive = infinitive;
            this.persons = persons;

            this.addTypage(this.tense);
            this.addTypage(this.infinitive != null ? this.infinitive.word : "unknown");
            this.addTypage(string.Join<Person>(", ", persons));
        }
    }
}
