using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvParser
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvTable tbl = CsvTable.Parse(@"C:\Users\hypesystem\Dropbox\Public\programmering\DataMining2\data.csv");

            Console.WriteLine("Rows: " + tbl.Rows.Count());
            Console.ReadKey();
        }
    }
}
