using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining2
{
    class LooseNominals
    {

        public static string[] Parse(string str)
        {
            string[] result = { };

            if (str.Contains(','))
            {
                result = str.Split(',');
            }
            else
            {
                result = str.Split(' ');
            }
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i].Trim();
            }
            return result;
        }

    }
}
