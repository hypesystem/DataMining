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
            CleanData();
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

                tup.Put("source", "data-2013");
                tup.Put("age", LooseInt.Parse(r.Data[0]));
                tup.Put("DOB", LooseDate.Parse(r.Data[1]));
                tup.Put("prog_skill", LooseInt.Parse(r.Data[2]));
                tup.Put("yrs_of_uni_study", LooseDouble.Parse(r.Data[3]));
                tup.Put("os", LooseNominal.Parse(r.Data[4]));
                tup.Put("prog_langs", LooseNominals.Parse(r.Data[5]));
                tup.Put("english_level", LooseInt.Parse(r.Data[6], 45, 69));
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

            Console.WriteLine("\n2013 data read.\n");
            Console.ReadKey();

            CsvTable tbl2014 = CsvTable.Parse(INPUT_PATH_2014);
            foreach (var r in tbl2014.Rows)
            {
                CrazyTuple tup = new CrazyTuple();

                tup.Put("source", "data-2014");
                tup.Put("age", LooseInt.Parse(r.Data[0]));
                tup.Put("prog_skill", LooseInt.Parse(r.Data[1]));
                tup.Put("yrs_of_uni_study", LooseDouble.Parse(r.Data[2]));
                tup.Put("os", LooseNominal.Parse(r.Data[3]));
                tup.Put("prog_langs", LooseNominals.Parse(r.Data[4]));
                tup.Put("english_level", LooseInt.Parse(r.Data[5], 45, 69));
                tup.Put("animal", LooseNominal.Parse(r.Data[6]));
                tup.Put("more_mountains_in_dk", LooseBinary.Parse(r.Data[7]));
                tup.Put("fed_up_with_winter", LooseBinary.Parse(r.Data[8]));
                tup.Put("randomNumber", LooseDouble.Parse(r.Data[9], 1, 10));
                tup.Put("randomRealNumber", LooseDouble.Parse(r.Data[10], 0, 1));
                tup.Put("randomRealNumber2", LooseDouble.Parse(r.Data[11], 0, 1));
                tup.Put("food_in_canteen_comment", r.Data[12]);
                tup.Put("favourite_color", LooseNominal.Parse(r.Data[13]));
                tup.Put("do_you_know_neural_network", LooseBinary.Parse(r.Data[14]));
                tup.Put("do_you_know_vector_machine", LooseBinary.Parse(r.Data[15]));
                tup.Put("do_you_know_sql", LooseBinary.Parse(r.Data[16], "sequential", "query", "language"));
                tup.Put("favourite_sql_server", LooseNominal.Parse(r.Data[17]));
                tup.Put("do_you_know_a_priori", LooseBinary.Parse(r.Data[18]));
                tup.Put("sqrt_number", LooseNominal.Parse(r.Data[19]));
                tup.Put("georgios_middlename", LooseNominal.Parse(r.Data[20]));
                tup.Put("julian_hometown", LooseNominal.Parse(r.Data[21]));
                tup.Put("gibberish_comment", r.Data[22]);
                tup.Put("planets_in_solar_system", LooseInt.Parse(r.Data[23]));
            }

            Console.WriteLine("\n2014 data read.\n");
            Console.ReadKey();
        }

        public static void CleanData()
        {
            //First pass: Make nominals
            var osNominals = new NominalSet();
            var progLangNominals = new NominalSet();
            var animalNominals = new NominalSet();
            var colorNominals = new NominalSet();
            var sqlServerNominals = new NominalSet();
            foreach (var tup in content)
            {
                osNominals.Add(tup.Get<string>("os"));
                foreach (string progLang in tup.Get<string[]>("prog_langs"))
                {
                    progLangNominals.Add(progLang);
                }
                animalNominals.Add(tup.Get<string>("animal"));
                colorNominals.Add(tup.Get<string>("favourite_color"));
                sqlServerNominals.Add(tup.Get<string>("favourite_sql_server"));
            }

            Console.Write("OS ("+osNominals.Count()+"): ");
            foreach (string os in osNominals)
            {
                Console.Write(os + "; ");
            }
            Console.WriteLine();

            Console.Write("ProgLang (" + progLangNominals.Count() + "): ");
            foreach (string progLang in progLangNominals)
            {
                Console.Write(progLang + "; ");
            }
            Console.WriteLine();

            Console.Write("Animal (" + animalNominals.Count() + "): ");
            foreach (string animal in animalNominals)
            {
                Console.Write(animal + "; ");
            }
            Console.WriteLine();

            Console.Write("Color (" + colorNominals.Count() + "): ");
            foreach (string color in colorNominals)
            {
                Console.Write(color + "; ");
            }
            Console.WriteLine();

            Console.Write("SQL Server (" + sqlServerNominals.Count() + "): ");
            foreach (string sqlServer in sqlServerNominals)
            {
                Console.Write(sqlServer + "; ");
            }
            Console.WriteLine();

            //Second pass: Make new tuples
            List<CrazyTuple> newContent = new List<CrazyTuple>();
            foreach (var tup in content)
            {
                //Throw away values that do not appear in both data sets
            }

            //Replace data
            content = newContent;
        }
    }
}
