using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining2
{
    /// <summary>
    /// This tuple is shit, but will do for now
    /// </summary>
    public class CrazyTuple
    {
        private Dictionary<string, object> storage = new Dictionary<string,object>();

        public CrazyTuple(params object[] values) {
        }

        public void Put(string name, object value)
        {
            storage[name] = value;
        }

        public T Get<T>(string name)
        {
            return (T)storage[name];
        }
    }
}
