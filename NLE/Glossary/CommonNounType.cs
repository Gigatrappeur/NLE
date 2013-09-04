using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{

    class CommonNounType: NounType
    {
        public enum Gender
        {
            Masculine,
            Feminine,
            Neuter,
            Unknown
        }

        public enum Number
        {
            Singular,
            Plural,
            Unknown
        }

        public Gender gender { get; private set; }
        public Number number { get; private set; }

        public CommonNounType(Gender gender, Number number)
            :base()
        {
            this.gender = gender;
            this.number = number;
        }

        public override string ToString()
        {
            return "[common noun, " + this.gender.ToString().ToLower() + ", " + this.number.ToString().ToLower() + "]";
        }
    }
}
