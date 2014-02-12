using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataMining2
{
    class LooseNominal
    {

        public static string Parse(string input)
        {
            Regex matchNonAlphanumeric = new Regex(@"[^a-z0-9#\+\.]");
            string result = matchNonAlphanumeric.Replace(input.Trim().ToLower(), "");
            return result == "" ? null : result;
        }

    }
}
