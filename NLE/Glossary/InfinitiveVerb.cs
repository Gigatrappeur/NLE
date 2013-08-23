using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public class InfinitiveVerb : Verb
    {

        // doit contenir une table de conjugaison : liste des conjugaison du verbe par personne et par temps


        public InfinitiveVerb(string v)
            : base(v)
        {
            this.addTypage("Infinitif");

        }
    }
}
