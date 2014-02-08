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
        const string INPUT_PATH = @"C:\Users\hypesystem\Dropbox\Public\programmering\DataMining2\data.csv";
        const string OUTPUT_PATH = @"C:\Users\hypesystem\Dropbox\Public\programmering\DataMining2\clean.csv";

        static void Main(string[] args)
        {
            CsvTable tbl = CsvTable.Parse(INPUT_PATH);
            int i = 0;
            foreach (var r in tbl.Rows)
            {
                Console.WriteLine("==============  #" + i + "  =============");
                i++;
                int? age = LooseInt.Parse(r.Data[0]);
                LooseDate date = LooseDate.Parse(r.Data[1]);
                int? prog_skill = LooseInt.Parse(r.Data[2]);
                double? yrs_of_uni_study = LooseDouble.Parse(r.Data[3]);
                string os = LooseNominal.Parse(r.Data[4]);
                string[] prog_lang = LooseNominals.Parse(r.Data[5]);
                int? english_level = LooseInt.Parse(r.Data[6]);
                string animal = LooseNominal.Parse(r.Data[7]);
                bool? more_mountains_in_dk = LooseBinary.Parse(r.Data[8]);
                bool? fed_up_with_winter = LooseBinary.Parse(r.Data[9]);
                double? randomNumber = LooseDouble.Parse(r.Data[10], 1, 10);
                double? randomRealNumber = LooseDouble.Parse(r.Data[11], 0, 1);
                double? randomRealNumber2 = LooseDouble.Parse(r.Data[12], 0, 1);
                string food_in_canteen_comment = r.Data[13];
                string favourite_color = LooseNominal.Parse(r.Data[14]);
                bool? do_you_know_neural_network = LooseBinary.Parse(r.Data[15]);
                bool? do_you_know_sql = LooseBinary.Parse(r.Data[16],"sequential", "query", "language");
                string favourite_sql_server = LooseNominal.Parse(r.Data[17]);
                bool? do_you_know_a_priori = LooseBinary.Parse(r.Data[18]);
                string sqrt_number = LooseNominal.Parse(r.Data[19]);
                string noor_shaker_hometown = LooseNominal.Parse(r.Data[20]);
                string gibberish_comment = r.Data[21];
                int? planets_in_solar_system = LooseInt.Parse(r.Data[22]);
                int? number_row = LooseInt.Parse(r.Data[23]);
                string name_sequence_above = LooseNominal.Parse(r.Data[24]);

                //TODO: Potential inconsistencies between DOB and Age
            }

            Console.ReadKey();
        }
    }
}
