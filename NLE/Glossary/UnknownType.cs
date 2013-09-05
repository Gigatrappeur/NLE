using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLE.Glossary
{
    public class UnknownType : WordType
    {
        public override string ToString()
        {
            return "[" + Utils.translate("unknown") + "]";
        }
    }
}
