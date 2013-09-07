using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Engine
{
    /// <summary>
    /// Représente une règle.
    /// 
    /// Une règle d'inférence est composé de prémisses permettant d'obtenir une conclusion.
    /// </summary>
    //  Exemple :
    //      rule 1 : PHRASE - SUJET VERBE
    //      rule 2 : PHRASE - SUJET VERBE COD
    //      ...
    //      
    //      rule r : SUJET - Determinant Noun
    //      ...
    class StringRule
    {
        public string conclusion { get; private set; }
        public string[] premises { get; private set; }


        public StringRule(string conclusion, string[] premises)
        {
            this.conclusion = conclusion;
            this.premises = premises;
        }


        public override string ToString()
        {
            return "Rule [" + this.conclusion + " - " + string.Join(" ", this.premises) + "]";
        }
    }
}
