using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEengProject2450
{
    class Book
    {
         public string title { get; private set; }
        public string author { get; private set; }
        public string genre { get; private set; }
        public string[] copies { get; set; }
        public string ageGroup { get; private set; }
        public int numCopies { get; set; }
        public int availible { get; set; }

        public Book(string t, string a, string g, string age,string avail)
        {
            title = t;  
            author = a;
            genre = g;
            copies  = avail.Split(',');
            numCopies = copies.Length;
            ageGroup = age;
            availible = 0;
            foreach(string i in copies)
            {
                if (i == "in")
                    availible++;
            }
        }
    }
}
