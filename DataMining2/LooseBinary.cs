using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining2
{
    class LooseBinary
    {

        public static bool? Parse(string boolstr, params string[] right_answers)
        {
            boolstr = boolstr.ToLower().Trim();
            bool is_yes = boolstr.Contains("yes");
            bool is_no = boolstr.Contains("no");

            if (is_yes && !is_no) return true;
            if (!is_yes && is_no) return false;

            if(!is_yes && !is_no) {
                foreach (string right_answer in right_answers)
                {
                    if (boolstr.Contains(right_answer)) return true;
                }
            }

            Console.WriteLine("Could not parse Binary: " + boolstr);
            return null;
        }

    }
}
