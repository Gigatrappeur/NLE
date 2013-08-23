using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public class Noun : Word
    {

        // gender : masculine, feminine and neuter
        

        // Classification :
        //   Proper nouns and common nouns
        //   Countable and uncountable nouns
        //   Collective nouns
        //   Concrete nouns and abstract nouns


        public Noun(string n)
            : base(n)
        {
            this.addTypage("Noun");


            // --  temporaire  ------------------------------------------------------------------------------
            switch (n)
            {
                case "test": this.addTypage("masculin, singulier"); break;
                case "atome": this.addTypage("masculin, singulier"); break;
            }
            // --  temporaire  ------------------------------------------------------------------------------

        }
    }
}
