using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace SoftwareEengProject2450
{
    class DataBaseReadWrite
    {
        //variables used to write data to a file
        private Stream fs;
        private BinaryFormatter bf;
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
        /// <summary>
        /// Pre-Condition - a sorted dictionary of all media is passed in
        /// Post-Condition - the data is serialized and written to a file
        /// </summary>
        void writeCatalog(SortedDictionary<uint,Media> m)
        {
            //
            SaveFileDialog save = new SaveFileDialog();
            try
            {
                save.Filter = "bin files (*.bin)|*.bin";
                save.AddExtension = true;
                save.FileName = "patronData";
                save.DefaultExt = "bin";
                save.RestoreDirectory = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if ((fs = save.OpenFile()) != null)
                    {
                        bf = new BinaryFormatter();
                        bf.Serialize(fs, m);
                        fs.Close();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Pre-Condition - a sorted dictionary of all patrons is passed in
        /// Post-Condition - the data is serialized and written to a file 
        /// </summary>
        void writePatron(SortedDictionary<uint, Patron> p)
        {

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
