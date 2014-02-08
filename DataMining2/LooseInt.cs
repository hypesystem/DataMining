using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataMining2
{
    class LooseInt
    {

        public static int? Parse(string intstr)
        {
            int val;
            if (int.TryParse(intstr.Trim(), out val))
            {
                return val;
            }

            //Try to parse as double, then round
            double? dblval = LooseDouble.Parse(intstr);
            if(dblval != null) {
                val = (int)Math.Round((double)dblval);
                Console.WriteLine("Warning: Approximating int " + val + " from double " + dblval);
                return val;
            }

            //Handle people putting in intervals (8-9, 8 or 9)
            Regex intervalsRegex = new Regex(@"([0-9]+)[^0-9]+([0-9]+)");
            Match intervalsMatch = intervalsRegex.Match(intstr);
            if (intervalsMatch.Success)
            {
                //Find average of two numbers
                int i1 = int.Parse(intervalsMatch.Groups[1].ToString());
                int i2 = int.Parse(intervalsMatch.Groups[2].ToString());

                val = (int)Math.Round((i1 + i2) / 2.0);


                //TODO: Why does this approximate 8 instead of 9 from 8-9?
                Console.WriteLine("Warning: Approximating int " + val + " from interval " + i1 + "-" + i2);
                return val;
            }

            Console.WriteLine("Couldn't parse int: " + intstr);
            return null;
        }

    }
}
