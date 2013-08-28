using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Engine
{

    // représente une personne
    public class Person : IComparable<Person>
    {
        private int ordre;
        public int position { get; private set; }
        public string number { get; private set; }
        public string personal_pronoun { get; private set; }
        public string description { get; private set; }


        public Person(int ordre, int position, string number, string personal_pronoun, string description)
        {
            this.ordre = ordre;
            this.position = position;
            this.number = number;
            this.personal_pronoun = personal_pronoun;
            this.description = description;
        }


        public override string ToString()
        {
            return this.description + " (" + this.personal_pronoun + ")";
        }

        public int CompareTo(Person other)
        {
            return this.ordre.CompareTo(other.ordre);
        }
    }
}
