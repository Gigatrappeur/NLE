using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE
{
    public class Verb : Word
    {
        // table de conjugaison ?
        // table de pronom ?


        // conjugué ? temps, à quelle personne

        // il faut une référence au verbe à l'infinitif.

        public Verb(string v)
            : base(v, "Verb")
        {

            // --  temporaire  ------------------------------------------------------------------------------
            switch (v)
            {
                case "tester": this.addTypage("infinitif"); break;
                case "testera": this.addTypage("futur simple, tester, 3ieme personne singulier"); break;
                case "mordre": this.addTypage("infinitif"); break;
            }
            // --  temporaire  ------------------------------------------------------------------------------

        }

    }
}
