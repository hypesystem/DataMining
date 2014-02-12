using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataMining2
{
    class LooseNominals
    {

        public static string[] Parse(string str)
        {
            string[] result = { };

            Regex nonAlphanumericSpace = new Regex(@"[^a-zA-Z0-9#\+\. ]");

            if (nonAlphanumericSpace.Match(str).Success)
            {
                //Split by everything!
                result = nonAlphanumericSpace.Split(str);
            }
            else
            {
                //Split by spaces
                result = str.Split(' ');
            }
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = LooseNominal.Parse(result[i]);
            }
            return result;
        }

    }
}
