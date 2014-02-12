using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataMining2
{
    public class NominalSet : IEnumerable<string>
    {
        private HashSet<string> storage = new HashSet<string>();

        public void Add(string nominal)
        {
            var result = nominal;
            if (result != "") storage.Add(result);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return storage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
