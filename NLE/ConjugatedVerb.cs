using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public class ConjugatedVerb : Verb
    {

        public string temps { get; private set; }
        
        public InfinitiveVerb infinitif { get; private set; } // référence vers le verbe à l'infinitif

        // il peut correspondre à plusieurs personnes
        public string personne { get; private set; }

        public ConjugatedVerb(string v, string temps, InfinitiveVerb infinitif, string personne)
            : base(v)
        {
            this.addTypage("Conjugué");

            this.temps = temps;
            this.infinitif = infinitif;
            this.personne = personne;

            this.addTypage(temps);
            this.addTypage(infinitif != null ? infinitif.word : "unknown");
            this.addTypage(personne);
        }
    }
}
