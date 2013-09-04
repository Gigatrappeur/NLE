using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public class NounType : WordType
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


        public override string ToString()
        {
            return "[noun]";
        }
    }
}
