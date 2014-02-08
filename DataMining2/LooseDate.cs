using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataMining2
{
    class LooseDate
    {
        public int? Day;
        public int? Month; //1 - 12
        public int? Year;

        public static LooseDate Parse(string datestring)
        {
            Regex numericDateRegex = new Regex(@"([0-9]{1,2})[^0-9a-zA-Z]+([0-9]{1,2})([^0-9a-zA-Z]+([0-9]{1,4}))?");
            //Numeric dates - we do not know if group 1 or 2 is the day, but let's assume europeans
            Match numMatches = numericDateRegex.Match(datestring);
            if (numMatches.Success)
            {
                int day = int.Parse(numMatches.Groups[1].ToString());
                int month = int.Parse(numMatches.Groups[2].ToString());
                int? year = null;

                Group yearGroup = numMatches.Groups[4];
                if (yearGroup != null && yearGroup.ToString() != "")
                {
                    year = int.Parse(yearGroup.ToString());
                }

                if (day > 31 || month > 12)
                {
                    int tmp = day;
                    day = month;
                    month = tmp;
                }

                if (year < 1000)
                {
                    if (year < 15) year += 2000;
                    else year += 1900;
                }

                return new LooseDate()
                {
                    Day = day,
                    Month = month,
                    Year = year
                };
            }


            //2char numeric dates
            Regex num2charRegex = new Regex(@"([0-9]{2})([0-9]{2})([0-9]{2})");
            Match num2charMatches = num2charRegex.Match(datestring);
            if (num2charMatches.Success)
            {
                int day = int.Parse(num2charMatches.Groups[1].ToString());
                int month = int.Parse(num2charMatches.Groups[2].ToString());
                int year = int.Parse(num2charMatches.Groups[3].ToString());

                if (day > 31 || month > 12)
                {
                    int tmp = day;
                    day = month;
                    month = tmp;
                }

                if (year < 15) year += 2000;
                else year += 1900;

                return new LooseDate()
                {
                    Day = day,
                    Month = month,
                    Year = year
                };
            }


            //String months in dates
            Regex strRegex = new Regex(@"([0-9]{1,2})[^0-9A-Za-z]+([a-zA-Z]{3,9})([^0-9A-Za-z]+([0-9]{1,4}))?");
            Match strMatch = strRegex.Match(datestring);
            if (strMatch.Success)
            {
                string monthstr = strMatch.Groups[2].ToString();
                int? month = ParseMonth(monthstr);

                int? year = null;
                if (strMatch.Groups[4].ToString() != "")
                {
                    year = int.Parse(strMatch.Groups[4].ToString());
                }

                int day = int.Parse(strMatch.Groups[1].ToString());

                return new LooseDate()
                {
                    Day = day,
                    Month = month,
                    Year = year
                };
            }


            //Str months, month first, then date - no year
            Regex strMonthFirstRegex = new Regex(@"([a-zA-Z]{3,9})[^0-9A-Za-z]+([0-9]{1,2})");
            Match strMonthFirstMatch = strMonthFirstRegex.Match(datestring);
            if (strMonthFirstMatch.Success)
            {
                string monthstr = strMonthFirstMatch.Groups[1].ToString();
                int? month = ParseMonth(monthstr);

                int day = int.Parse(strMonthFirstMatch.Groups[2].ToString());

                return new LooseDate()
                {
                    Day = day,
                    Month = month,
                    Year = null
                };
            }


            //Echo unhandled value
            Console.WriteLine("Could not parse date: " + datestring);

            return new LooseDate()
            {
                Day = null,
                Month = null,
                Year = null
            };
        }

        public static int? ParseMonth(string monthstr)
        {
            monthstr = monthstr.ToLower();
            switch (monthstr)
            {
                case "jan": case "januar":
                    return 1;
                case "feb": case "february":
                    return 2;
                case "mar": case "march":
                    return 3;
                case "apr": case "april":
                    return 4;
                case "may":
                    return 5;
                case "jun": case "june":
                    return 6;
                case "jul": case "july":
                    return 7;
                case "aug": case "august":
                    return 8;
                case "sep": case "september":
                    return 9;
                case "oct": case "october":
                    return 10;
                case "nov": case "november":
                    return 11;
                case "dec": case "december":
                    return 12;
            }
            return null;
        }

        public override string ToString()
        {
            return (Year == null ? "XXXX" : Year.ToString()) + "-" +
                (Month == null ? "XX" : Month.ToString()) + "-" +
                (Day == null ? "XX" : Day.ToString());
        }
    }
}
