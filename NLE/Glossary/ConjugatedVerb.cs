using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public class ConjugatedVerb : Verb
    {
        // temps (futur, présent...)
        public string tense { get; private set; }

        // référence vers le verbe à l'infinitif
        public InfinitiveVerb infinitive { get; private set; } 

        // il peut correspondre à plusieurs personnes
        public string[] persons { get; private set; }


        public ConjugatedVerb(string v, string tense, InfinitiveVerb infinitive, string[] persons)
            : base(v)
        {
            this.addTypage("Conjugué");

            this.tense = tense;
            this.infinitive = infinitive;
            this.persons = persons;

            this.addTypage(this.tense);
            this.addTypage(this.infinitive != null ? this.infinitive.word : "unknown");
            this.addTypage(string.Join(", ", persons));
        }
    }
}
