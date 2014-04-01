using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEengProject2450
{
    class Patron
    {
        public string name { get; set; }
        public string address { get; set;}
        public uint age { get; set; }
        public string [] current_checkouts { get; set; }
        public string [] holds { get; set; }

        public Patron(string n, string a, uint ag, string check, string hold)
        {
            name = n;
            address = a;
            age = ag;
            current_checkouts = new string[7];
            current_checkouts = check.Split(',');
            holds = new string[5];
            holds = hold.Split(',');

        }
    }
}
