using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DataMining2
{
    class LooseDouble
    {

        public static double? Parse(string dblstr, double min = double.MinValue, double max = double.MaxValue)
        {

            dblstr = dblstr.Trim();

            if (dblstr == "") return null;

            double val;
            bool and_a_half = false;
            if (dblstr.Last() == 65533) //65533 == ½
            {
                and_a_half = true;
                dblstr = dblstr.Substring(0,dblstr.Length - 1);
            }

            if (!dblstr.Contains(',') && double.TryParse(dblstr, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out val))
            {
                if (and_a_half) val += 0.5;
                if (val < min || val > max)
                    Console.WriteLine("Warning: Parsing double " + val + " outside of limits, [" + min + "," + max + "]");
                return val;
            }
            if (double.TryParse(dblstr, NumberStyles.Any, CultureInfo.GetCultureInfo("da-DK"), out val))
            {
                if (and_a_half) val += 0.5;
                if (val < min || val > max)
                    Console.WriteLine("Warning: Parsing double " + val + " outside of limits, [" + min + "," + max + "]");
                return val;
            }
            if (and_a_half)
            {
                val = 0.5;
                if (val < min || val > max)
                    Console.WriteLine("Warning: Parsing double " + val + " outside of limits, [" + min + "," + max + "]");
                return val;
            }

            Console.WriteLine("Couldn't parse double: " + dblstr + " (with min " + min + " and max " + max + ")");
            return null;
        }

    }
}
