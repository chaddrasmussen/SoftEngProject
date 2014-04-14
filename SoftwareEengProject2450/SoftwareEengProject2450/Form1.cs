using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        private SortedDictionary<uint, Media> mediaSD;
        private SortedDictionary<uint, Patron> patronSD;

        //stacks
        //each time a patron or media object is removed the id is stored on the stack. 
        //When adding new patrons or media items we will use numbers on the stack before adding new items.

        Stack patronIDs = new Stack();
        Stack mediaIDs = new Stack();
        uint mediaID;
        uint patronID;

        private Media m;
        DataBaseReadWrite db = new DataBaseReadWrite("patron.bin","media.bin");
        private string noPatron = "Error: No patron selected. Please click the patron's name, and then click the Select button.";
        private string noMedia = "Error: No media selected. Please click the name of the media to be checked in/out, and then click the Select button.";
        public Form1()
        {
            InitializeComponent();
            mediaSD = new SortedDictionary<uint, Media> { };
            patronSD = new SortedDictionary<uint, Patron> { };
            txtMediaType.SelectedIndex = 0;
            db.readCatalog(ref mediaSD);
            db.readPatron(ref patronSD);
            db.readIDs(out patronIDs, out mediaIDs);
            setMediaID();
            setPatronID();
        }

        /// <summary>
        /// Purpose: Sets the media ID based on what is in the media sorted dictionary and/or the media ID array
        /// </summary>
        private void setMediaID()
        {
            if (mediaSD.Count == 0)
            {
                mediaID = 10000;
            }
            else
            {
                if (mediaIDs.Count == 0)
                {
                    mediaID = mediaSD.Keys.Last() + 1;
                }
                else
                {
                    mediaID = (uint)mediaIDs.Pop();
                }
        }
            txtPatronCardNum.Text = mediaID.ToString();
        }

        /// <summary>
        /// Purpose: Sets the patron ID based on what is in the media sorted dictionary and/or the patron ID array
        /// </summary>
        private void setPatronID()
        {
            if (patronSD.Count == 0)
            {
                patronID = 10000;
            }
            else
            {
                if (patronIDs.Count == 0)
                {
                    patronID = patronSD.Keys.Last() + 1;
                }
                else
                {
                    patronID = (uint)patronIDs.Pop();
                }
            }
            txtMediaID.Text = patronID.ToString();
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
            txtDisplayPatron.Items.Clear();
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
            txtDisplayMedia.Items.Clear();
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
            Patron p;
            uint cardNumber;
            if (!uint.TryParse(txtRemovePatron.Text, out cardNumber))
            {

                MessageBox.Show("Please enter a valid library card number");
            }
            else
            {
                if (!patronSD.TryGetValue(cardNumber, out p))
                {
                    if (patronSD.Count == 0)
                    {
                        MessageBox.Show("No patrons to remove.");
            }            
                    else
                    MessageBox.Show("No patron with such ID exists.");
        }
                else
                {
                    patronIDs.Push(cardNumber);
                    MessageBox.Show("Removed "+p.ToString());
                    patronSD.Remove(cardNumber);

                }
            }
        }

        private void btnRemoveMedia_Click(object sender, EventArgs e)
        {
            uint i;
            Media M;
            if (!uint.TryParse(txtMediaRemoveID.Text, out i))
            {
                MessageBox.Show("Please enter a valid media ID number");
            }
            else
            {
                if (!mediaSD.TryGetValue(i, out M))
                {
                    if (mediaSD.Count == 0)
                    {
                        MessageBox.Show("No media items to remove.");
                    }
                    else
                    MessageBox.Show("No media with such ID exists.");
            }
            else
            {
                    MessageBox.Show(M.Title + " removed.");
                    mediaSD.Remove(i);
                    mediaIDs.Push(i);
                
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
                MessageBox.Show(noPatron);
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
                MessageBox.Show(noMedia);
            }
            
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            txtDisplayCheckInOut.Items.Remove(txtDisplayCheckInOut.SelectedItem);
        }


        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            CheckInMedia();            
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
           
            if (txtDisplayPatron.SelectedIndex == -1)
            {
                MessageBox.Show(noPatron);
            }
            if (txtDisplayMedia.SelectedIndex == -1)
            {
                MessageBox.Show(noMedia);
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

        /// <summary>
        /// Checks in the media
        /// </summary>
        /// <param name="media">media to be returned</param>
        /// <param name="patron">patron returning the media</param>
        private void CheckInMedia()
        {
            if (txtDisplayPatron.SelectedIndex == -1)
            {
                MessageBox.Show(noPatron);
            }
            if (txtDisplayMedia.SelectedIndex == -1)
            {
                MessageBox.Show(noMedia);
            }
            else
            {
                Patron patron = txtDisplayPatron.SelectedItem as Patron;
                Media media = txtDisplayMedia.SelectedItem as Media;

                if (patron._currentChecked.ContainsKey(media.ID))
                {
                    media.CheckIn();
                }
            }
        }

    }
}
