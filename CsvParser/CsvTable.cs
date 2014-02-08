using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CsvParser
{
    public class CsvTable
    {
        public static CsvTable Parse(string filename)
        {
            IsValidFile(filename);
            CsvTable result;
            using (TextReader reader = OpenFile(filename))
            {
                result = ParseFileStream(reader);
            }
            return result;
        }

        private static bool IsValidFile(string filename) {
            //TODO: implement
            return true;
        }

        private static TextReader OpenFile(string filename)
        {
            //TODO: Read as UTF8
            return File.OpenText(filename);
        }

        private static CsvTable ParseFileStream(TextReader reader)
        {
            string content = reader.ReadToEnd();
            string[] rows = content.Split('\n');

            CsvTable table = new CsvTable();

            foreach (string row in rows)
            {
                table.Append(new CsvRow(row.Split(';')));
            }

            return table;
        }

        public struct CsvRow
        {
            private readonly string[] _data;

            public CsvRow(string[] data)
            {
                _data = data;
            }

            public string[] Data
            {
                get
                {
                    return _data;
                }
            }
        }

        private List<CsvRow> rows = new List<CsvRow>();
        public CsvTable()
        {
        }

        public void Append(CsvRow row)
        {
            rows.Add(row);
        }

        public IEnumerable<string> Cols
        {
            get
            {
                return rows.First().Data;
            }
        }

        public IEnumerable<CsvRow> Rows
        {
            get
            {
                return rows.Skip(1);
            }
        }
    }
}
