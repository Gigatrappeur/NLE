using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public class Adjective : Word
    {

        public Adjective(string a)
            : base(a)
        {
            this.addTypage("Adjective");


        }
    }
}
