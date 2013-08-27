using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Engine
{

    // représente une personne
    public class Person
    {

        public int position { get; private set; }
        public string number { get; private set; }
        public string personal_pronoun { get; private set; }
        public string description { get; private set; }


        public Person(int position, string number, string personal_pronoun, string description)
        {
            this.position = position;
            this.number = number;
            this.personal_pronoun = personal_pronoun;
            this.description = description;
        }


        public override string ToString()
        {
            return this.description + " (" + this.personal_pronoun + ")";
        }
    }
}
