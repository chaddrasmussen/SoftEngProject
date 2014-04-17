using System;
using System.Collections.Generic;
using System.Collections;
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

        OpenFileDialog openMedia = new OpenFileDialog();
        OpenFileDialog openPatron = new OpenFileDialog();

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

        /// <summary>
        /// Purpose: reads in a file
        /// </summary>
        /// <param name="m"></param>
        public void readCatalog(ref SortedDictionary<uint, Media> m)
        {
            openMedia.Filter = "bin files (*.bin)|*.bin";
            openMedia.FilterIndex = 2 ;
            openMedia.RestoreDirectory = true ;
            MessageBox.Show("select media file");
            if (openMedia.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((mediaStream = openMedia.OpenFile()) != null)
                    {
                        using (mediaStream)
                        {
                            m = (SortedDictionary<uint, Media>)bf.Deserialize(mediaStream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                mediaStream.Close();
            }
    
            
            
        }

        /// <summary>
        /// Purpose: reads in a file
        /// </summary>
        /// <param name="p"></param>
        public void readPatron(ref SortedDictionary<uint, Patron> p)
        {
            openPatron.Filter = "bin files (*.bin)|*.bin";
            openPatron.FilterIndex = 2;
            openPatron.RestoreDirectory = true;
            MessageBox.Show("select patron file");
            if (openPatron.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((patronStream = openPatron.OpenFile()) != null)
                    {
                        using (patronStream)
                        {
                            p = (SortedDictionary<uint, Patron>)bf.Deserialize(patronStream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                patronStream.Close();
            }
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
    }
               
               
}
