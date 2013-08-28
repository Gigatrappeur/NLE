using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DicoManagement
{
    static class Utils
    {

        public static string firstLetterToUpper(string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
        }
    }
}
