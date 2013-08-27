using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using NLE.Engine;

namespace NLE.Glossary
{
    public class InfinitiveVerb : Verb
    {
        
        /// <summary>
        /// Contient les tables de conjugaison (par temps et par personne)
        /// </summary>
        public Dictionary<string, Dictionary<Person, ConjugatedVerb>> conjugationTables { get; set; }

        public InfinitiveVerb(string v)
            : base(v)
        {
            this.addTypage("Infinitif");

            this.conjugationTables = new Dictionary<string, Dictionary<Person, ConjugatedVerb>>();
        }


        public string ConjugationTablesToString()
        {
            string rt = "";

            foreach (var temps in this.conjugationTables)
            {
                rt += temps.Key + Environment.NewLine;

                foreach (var person in temps.Value)
                {
                    rt += person.Key + " : " + person.Value.word + Environment.NewLine;
                }

                rt += Environment.NewLine;
            }


            return rt;
        }
    }
}
