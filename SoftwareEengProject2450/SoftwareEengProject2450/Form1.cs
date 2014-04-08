using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            MessageBox.Show("closing");
            //serialize and write dictionary to file
            base.OnFormClosing(e);
        }

        private void btnDisplayAllPatrons_Click(object sender, EventArgs e)
        {
            //txtDisplayPatron.SelectedText = patron? 
            displayPatrons(new Patron());
        }
        /// <summary>
        /// Purpose: helper for btnDisplayAllPatrons
        /// </summary>
        /// <param name="patron">string = selected text from txtDisplayPatron</param>
        private void displayPatrons(Patron P)
        {
            for (int i = 0; i <  P._currentChecked.Count; i++)
            {
                txtDisplayPatron.Clear();
                foreach (KeyValuePair<uint, Media> p in P._currentChecked)
                {
                    txtDisplayPatron.Text += p.Value.ToString();
                    
                }
            }
        }
       
    }
}
