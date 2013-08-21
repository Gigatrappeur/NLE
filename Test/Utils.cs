using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    static class Utils
    {
        public static string ToString(System.Array a)
        {
            string rt = a.GetType().FullName + " (" + a.Length + ")" + Environment.NewLine + "[" + Environment.NewLine;

            foreach (var item in a)
            {
                rt += "\t" + item.ToString() + Environment.NewLine;
            }

            rt += "]" + Environment.NewLine;

            return rt;
        }
    }
}
