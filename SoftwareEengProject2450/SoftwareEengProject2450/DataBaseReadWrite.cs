using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SoftwareEengProject2450
{
    class DataBaseReadWrite
    {
        void readCatalog(StreamReader b, SortedDictionary<uint,Book> catalog)
        {
            uint i = 0;
            while (!b.EndOfStream)
            {
                string[] r = b.ReadLine().Split('\t');
                catalog[uint.Parse(r[0])] = new Book(r[1], r[2], r[3], r[4], r[5]);

                i++;
            }
            b.Close();
        }

        void readPatron(StreamReader b, SortedDictionary<uint, Patron> p)
        {
            uint i = 0;
            while (!b.EndOfStream)
            {
                string[] r = b.ReadLine().Split('\t');
                p[uint.Parse(r[0])] = new Patron(r[1], r[2], uint.Parse(r[3]), r[4], r[5]);

                i++;
            }
        }

        uint searchTitle(SortedDictionary<uint,Book> b, string n)
        {
            foreach (KeyValuePair<uint,Book> item in b)
            {
                if (item.Value.title.Contains(n))
                {
                    return item.Key;
                }
            }
            return 0;
            
        }
    }
               
               
}
