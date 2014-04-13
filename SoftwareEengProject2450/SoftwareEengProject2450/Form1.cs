using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        private SortedDictionary<uint, Media> mediaSD;
        private SortedDictionary<uint, Patron> patronSD;
        private Media m;
        DataBaseReadWrite db = new DataBaseReadWrite("patron.bin","media.bin");
        public Form1()
        {
            InitializeComponent();
            mediaSD = new SortedDictionary<uint, Media> { };
            patronSD = new SortedDictionary<uint, Patron> { };
            txtMediaType.SelectedIndex = 0;
            db.readCatalog(ref mediaSD);
            db.readPatron(ref patronSD);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void OnClosed(EventArgs e)
        {
            db.writeCatalog(mediaSD);
            db.writePatron(patronSD);
            base.OnClosed(e);
        }
        /// <summary>
        /// Purpose: to display all patrons
        /// </summary>
        private void btnDisplayAllPatrons_Click(object sender, EventArgs e)
        {
            txtDisplayPatron.Items.Clear();
            displayPatrons();
        }
        /// <summary>
        /// Purpose: helper for btnDisplayAllPatrons
        /// </summary>
        private void displayPatrons()
        {

            foreach (KeyValuePair<uint, Patron> p in this.patronSD)
            {
                txtDisplayPatron.Items.Add(p.Value);
            }
        }
        /// <summary>
        /// Purpose: to display all currently checked books per patron
        /// </summary>
        private void btnViewChkedPerPatron_Click(object sender, EventArgs e)
        {
            if (txtDisplayPatron.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a patron for which to view checked out media.");
            }
            else
            {
                Patron P = (Patron)txtDisplayPatron.SelectedItem; //=txtDisplayPatron.SelectedText
                displayChecked(P);
            }
            

        }
        /// <summary>
        /// Purpose: helper for btnDisplayCheckedPerPatron
        /// </summary>
        /// <param name="P">Patron</param>
        private void displayChecked(Patron P)
        {
            foreach (KeyValuePair<uint, Media> m in P._currentChecked)
            {
                MessageBox.Show(m.Value.ToString());

            }
        }
        /// <summary>
        /// Purpose: to display all media items
        /// </summary>
        private void btnDisplayAllMedia_Click(object sender, EventArgs e)
        {
            displayMedia();
        }
        private void displayMedia()
        {
            foreach (KeyValuePair<uint, Media> m in mediaSD)
            {
                txtDisplayMedia.Items.Add(m.Value);
            }
        }

        private void btnAddPatron_Click(object sender, EventArgs e)
        {
            saveNewPatron();
        }
        private void saveNewPatron()
        {
            if (Patron.validate(txtPatronName.Text, txtPatronAddress.Text, txtPatronCity.Text, txtPatronState.Text, txtPatronZip.Text, txtPatronPhone.Text, txtPatronCardNum.Text))
            {
                string combinedAddress = string.Concat(txtPatronAddress.Text, " ,", txtPatronCity.Text, ", ", txtPatronState.Text, ", ", txtPatronZip.Text);
                patronSD.Add(uint.Parse(txtPatronCardNum.Text), new Patron(txtPatronName.Text, uint.Parse(txtPatronCardNum.Text), combinedAddress, txtPatronPhone.Text, txtPatronDateofBirth.Value));
                MessageBox.Show("Patron added successfully!");
            }
        }
        private void btnAddMedia_Click(object sender, EventArgs e)
        {
            saveNewMedia();
        }
        private void saveNewMedia()
        {
            
            if (validateMedia())
            {
                if (txtMediaType.SelectedIndex == 1)
                {
                    m = new Media(txtMediaTitle.Text, txtMediaAuthor.Text, MediaType.ADULTBOOK);
                    mediaSD.Add(m.ID, m);
                }
                if (txtMediaType.SelectedIndex == 2)
                {
                    m = new Media(txtMediaTitle.Text,txtMediaAuthor.Text, MediaType.CHILDBOOK);
                    mediaSD.Add(m.ID, m);
                }
                if (txtMediaType.SelectedIndex == 3)
                {
                    m = new Media(txtMediaTitle.Text, txtMediaAuthor.Text,MediaType.DVD);
                    mediaSD.Add(m.ID, m);
                }
                if (txtMediaType.SelectedIndex == 4)
                {
                    m = new Media(txtMediaType.Text,txtMediaAuthor.Text, MediaType.VIDEO);
                    mediaSD.Add(m.ID, m);
                }
                MessageBox.Show("Media item '" +txtMediaTitle.Text+"' added successfully!");
            }
           
        }
        private bool validateMedia()
        {
            if (string.IsNullOrEmpty(txtMediaTitle.Text))
            {
                MessageBox.Show("Please enter a title to add a book.");
                return false;
            }
            if (string.IsNullOrEmpty(txtMediaAuthor.Text))
            {
                MessageBox.Show("Please enter the author to add a book.");
                return false;
            }
            if (txtMediaType.SelectedIndex == 0)
            {
                MessageBox.Show("Please choose a media type.");
                return false;
            }
            return true;
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            uint cardNumber;
            if(uint.TryParse(txtRemovePatron.Text,out cardNumber))
            {
                patronSD.Remove(cardNumber);
                MessageBox.Show("removed");
            }
            else
            {
                MessageBox.Show("Please enter a valid library card number");
            }            
        }

        private void btnRemoveMedia_Click(object sender, EventArgs e)
        {
            uint mediaID;
            if (uint.TryParse(txtMediaRemoveID.Text, out mediaID))
            {
                mediaSD.Remove(mediaID);
                MessageBox.Show("removed");
            }
            else
            {
                MessageBox.Show("Please enter a valid media ID number");
            }
        }

        private void btnClearGUI_Click(object sender, EventArgs e)
        {
            txtDisplayCheckInOut.Items.Clear();
            txtDisplayMedia.Items.Clear();
            txtDisplayPatron.Items.Clear();
            txtSearchMedia.Clear();
            txtSearchPatron.Clear();
            dateTimePicker.Value = DateTime.Today;
            btnDeselect.Enabled = false;
        }

        private void btnDisplayOverdue_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<uint, Media> mm in this.mediaSD)
            {
                if(mm.Value.Overdue(dateTimeOverdue.Value))
                {
                    displayOverdueMedia.Text += mm.Value.ToString();
                }
            }  
        }

        private void btnSelectPatron_Click(object sender, EventArgs e)
        {
            if (txtDisplayPatron.SelectedIndex != -1)
            {
                txtDisplayCheckInOut.Items.Add(txtDisplayPatron.SelectedItem);
                btnDeselect.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error: No patron selected.");
            }     
        }

        private void btnSelectMedia_Click(object sender, EventArgs e)
        {
            if (txtDisplayMedia.SelectedIndex != -1)
            {
                txtDisplayCheckInOut.Items.Add(txtDisplayMedia.SelectedItem);
                btnDeselect.Enabled = true;
              
            }
            else
            {
                MessageBox.Show("Error: No media selected.");
            }
            
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            txtDisplayCheckInOut.Items.Clear();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            //object[] o = new object[2];
            //for (int i = 0; i < 2; i++)
            //{
            //    o[i] = txtDisplayCheckInOut.Items;
            //}
            if (txtDisplayPatron.SelectedIndex == -1)
            {
                MessageBox.Show("Error: No patron selected");
            }
            if (txtDisplayMedia.SelectedIndex == -1)
            {
                MessageBox.Show("Error: No media selected");
            }
            else
            {
                Patron p = (Patron)txtDisplayPatron.SelectedItem;
                Media m = (Media)txtDisplayMedia.SelectedItem;
                if (!p.overdueBooks(dateTimePicker.Value) && p.allowed(m))
                {
                    m.CheckOut(p, dateTimePicker.Value);
                }
            }
        }

    }
}
