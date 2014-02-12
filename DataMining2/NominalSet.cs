using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataMining2
{
    public class NominalSet : IEnumerable<KeyValuePair<string,int>>
    {
        private Dictionary<string, int> storage = new Dictionary<string, int>();

        public void Add(string nominal)
        {
            if (nominal != null)
            {
                if (storage.ContainsKey(nominal))
                    storage[nominal]++;
                else
                    storage[nominal] = 1;
            }
        }

        public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
        {
            return storage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
