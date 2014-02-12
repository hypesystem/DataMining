using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvParser;

namespace DataMining2
{
    class Program
    {
        const string INPUT_PATH_2013 = @"C:\Users\hypesystem\Dropbox\Public\programmering\DataMining2\data-2013.csv";
        const string INPUT_PATH_2014 = @"C:\Users\hypesystem\Dropbox\Public\programmering\DataMining2\data-2014.csv";
        const string OUTPUT_PATH = @"C:\Users\hypesystem\Dropbox\Public\programmering\DataMining2\clean.csv";

        private static List<CrazyTuple> content = new List<CrazyTuple>();

        static void Main(string[] args)
        {
            ReadAndParseData();
            Console.ReadKey();
            //CleanData();
            Console.ReadKey();
            //NormalizeData();
            Console.ReadKey();
            //ClassifyData();
            Console.ReadKey();
        }

        static void ReadAndParseData()
        {
            CsvTable tbl2013 = CsvTable.Parse(INPUT_PATH_2013);
            foreach (var r in tbl2013.Rows)
            {
                CrazyTuple tup = new CrazyTuple();

                tup.Put("source", "old-data");
                tup.Put("age", LooseInt.Parse(r.Data[0]));
                tup.Put("date", LooseDate.Parse(r.Data[1]));
                tup.Put("prog_skill", LooseInt.Parse(r.Data[2]));
                tup.Put("yrs_of_uni_study", LooseDouble.Parse(r.Data[3]));
                tup.Put("os", LooseNominal.Parse(r.Data[4]));
                tup.Put("prog_langs", LooseNominals.Parse(r.Data[5]));
                tup.Put("english_level", LooseInt.Parse(r.Data[6]));
                tup.Put("animal", LooseNominal.Parse(r.Data[7]));
                tup.Put("more_mountains_in_dk", LooseBinary.Parse(r.Data[8]));
                tup.Put("fed_up_with_winter", LooseBinary.Parse(r.Data[9]));
                tup.Put("randomNumber", LooseDouble.Parse(r.Data[10], 1, 10));
                tup.Put("randomRealNumber", LooseDouble.Parse(r.Data[11], 0, 1));
                tup.Put("randomRealNumber2", LooseDouble.Parse(r.Data[12], 0, 1));
                tup.Put("food_in_canteen_comment", r.Data[13]);
                tup.Put("favourite_color", LooseNominal.Parse(r.Data[14]));
                tup.Put("do_you_know_neural_network", LooseBinary.Parse(r.Data[15]));
                tup.Put("do_you_know_sql", LooseBinary.Parse(r.Data[16], "sequential", "query", "language"));
                tup.Put("favourite_sql_server", LooseNominal.Parse(r.Data[17]));
                tup.Put("do_you_know_a_priori", LooseBinary.Parse(r.Data[18]));
                tup.Put("sqrt_number", LooseNominal.Parse(r.Data[19]));
                tup.Put("noor_shaker_hometown", LooseNominal.Parse(r.Data[20]));
                tup.Put("gibberish_comment", r.Data[21]);
                tup.Put("planets_in_solar_system", LooseInt.Parse(r.Data[22]));
                tup.Put("number_row", LooseInt.Parse(r.Data[23]));
                tup.Put("name_sequence_above", LooseNominal.Parse(r.Data[24]));

                //TODO: Potential inconsistencies between DOB and Age

                content.Add(tup);
            }
        }
    }
}
