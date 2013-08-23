using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public class Verb : Word
    {

        public Verb(string v)
            : base(v)
        {

            this.addTypage("Verb");


        }

    }
}
