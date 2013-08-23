using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLE.Glossary;

namespace NLE.Engine
{
    public class Prediction
    {

        public static Word[] simple(Words dictionary, string startWord)
        {
            return dictionary.getAll(startWord);
        }

    }
}
