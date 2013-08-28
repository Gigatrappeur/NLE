using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public class UnknownWord : Word
    {

        public UnknownWord(string u, string definition)
            : base(u, definition)
        {
            this.addTypage("Unknown");
        }
    }
}
