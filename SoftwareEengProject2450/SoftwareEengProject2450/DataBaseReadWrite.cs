using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace Library
{
    class DataBaseReadWrite
    {
        //variables used to write data to a file
        private Stream mediaStream;
        private Stream patronStream;
        private BinaryFormatter bf;
        void readCatalog(SortedDictionary<uint, Media> m)
        {
            mediaStream = new FileStream("media.bin", FileMode.OpenOrCreate);
            try 
            { 
                m = (SortedDictionary<uint,Media>)bf.Deserialize(mediaStream);
            }
            catch
            {
                MessageBox.Show("empty file");
            }
            
        }

        void readPatron(SortedDictionary<uint, Patron> p)
        {
            patronStream = new FileStream("patron.bin", FileMode.OpenOrCreate);
            try
            {
                p = (SortedDictionary<uint, Patron>)bf.Deserialize(mediaStream);
            }
            catch
            {
                MessageBox.Show("empty file");
            }
        }
        /// <summary>
        /// Pre-Condition - a sorted dictionary of all media is passed in
        /// Post-Condition - the data is serialized and written to a file
        /// </summary>
        void writeCatalog(SortedDictionary<uint,Media> m)
        {
            try
            {
                bf.Serialize(mediaStream, m);
                mediaStream.Close();
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
            try
            {
                bf.Serialize(patronStream, p);
                patronStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //uint searchTitle(SortedDictionary<uint,MediaObject> b, string n)
        //{
        //    foreach (KeyValuePair<uint,MediaObject> item in b)
        //    {
        //        if (item.Value.title.Contains(n))
        //        {
        //            return item.Key;
        //        }
        //    }
        //    return 0;
            
        //}
    }
               
               
}
