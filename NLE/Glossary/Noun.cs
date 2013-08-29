using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public class Noun : Word
    {

        // gender : masculine, feminine and neuter

        // si masculin, mettre une référence sur le feminin (et inversement) (si c'est possible !)
        // idem pour le singulier/pluriel
        
        // comment faire pour les noms propres ? On les stockes ?

        // Classification :
        //   Proper nouns and common nouns
        //   Countable and uncountable nouns
        //   Collective nouns
        //   Concrete nouns and abstract nouns


        public Noun(string n, string[] attributs, string definition)
            : base(n, definition)
        {
            this.addTypage("Noun");



            // --  temporaire  ------------------------------------------------------------------------------
            for (int i = 0; i < attributs.Length; i++)
                this.addTypage(attributs[i]);

            /*switch (n)
            {
                case "test": this.addTypage("masculin, singulier"); break;
                case "atome": this.addTypage("masculin, singulier"); break;
            }*/
            // --  temporaire  ------------------------------------------------------------------------------

        }
    }
}
