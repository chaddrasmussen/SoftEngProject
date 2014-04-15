using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace Library
{
    public class DataBaseReadWrite
    {
        //variables used to write data to a file
        private Stream mediaStream;
        private Stream patronStream;
        private BinaryFormatter bf = new BinaryFormatter();
        public string mediaFile { get; set; }
        public string patronFile { get; set; }
        /// <summary>
        /// Purpose: takes two stacks and writes them to file
        /// </summary>
        /// <param name="pIDs"></param>
        /// <param name="mIDs"></param>
        public void writeIDs (Stack pIDs, Stack mIDs)
        {
            object[] tempP;
            object[] tempM;
            tempP = pIDs.ToArray();
            tempM = mIDs.ToArray();
            StreamWriter fileP = new StreamWriter(@"Pdata.txt");
            StreamWriter fileM = new StreamWriter(@"Mdata.txt");
            foreach (object o in tempP)
            {
                fileP.WriteLine(o.ToString());
            }
            foreach (object o in tempM)
            {
                fileM.WriteLine(o.ToString());
            }
            fileP.Close();
            fileM.Close();
        }

        /// <summary>
        /// Purpose: reads saved ID's from file and outs them to stacks
        /// </summary>
        /// <param name="pIDs"></param>
        /// <param name="mIDs"></param>
        public void readIDs(out Stack pIDs, out Stack mIDs)
        {
            StreamReader fileP;
            Stack temp = new Stack();
            

            string line;
           
            StreamReader fileM;
            if (File.Exists("Pdata.txt"))
            {
                fileP = new StreamReader(@"Pdata.txt");
                while ((line = fileP.ReadLine()) != null)
                {
                    temp.Push(line);
                }
                pIDs = (Stack)temp.Clone();
                temp.Clear();
                line = "";
                fileP.Close();
            }
            else
                pIDs = new Stack();
            if(File.Exists("Mdata.txt"))
            {
                fileM = new StreamReader(@"Mdata.txt");
                while ((line = fileM.ReadLine()) != null)
                {
                    temp.Push(line);
                }
                mIDs = temp;
                fileM.Close();
            }
            else
                mIDs = new Stack();
            
            
            
            
        }
        public DataBaseReadWrite(string p,string m)
        {
            mediaFile = m;
            patronFile = p;
        }

        public void readCatalog(ref SortedDictionary<uint, Media> m)
        {
            mediaStream = new FileStream(mediaFile, FileMode.OpenOrCreate);
            try 
            { 
                m = (SortedDictionary<uint,Media>)bf.Deserialize(mediaStream);
            }
            catch
            {
                MessageBox.Show("empty file");
            }
            mediaStream.Close();
        }

        public void readPatron(ref SortedDictionary<uint, Patron> p)
        {
            patronStream = new FileStream(patronFile, FileMode.OpenOrCreate);
            try
            {
                p = (SortedDictionary<uint, Patron>)bf.Deserialize(patronStream);
            }
            catch
            {
                MessageBox.Show("empty file");
            }
            patronStream.Close();
        }
        /// <summary>
        /// Pre-Condition - a sorted dictionary of all media is passed in
        /// Post-Condition - the data is serialized and written to a file
        /// </summary>
        public void writeCatalog(SortedDictionary<uint,Media> m)
        {
            mediaStream = new FileStream(mediaFile, FileMode.Create);
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
        public void writePatron(SortedDictionary<uint, Patron> p)
        {
            patronStream = new FileStream(patronFile, FileMode.Create);
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
