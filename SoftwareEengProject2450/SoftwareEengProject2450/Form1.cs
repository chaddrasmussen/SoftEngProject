using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library
{
    /// <summary>
    /// Purpose: GUI for Library Manager
    /// </summary>
    public partial class Form1 : Form
    {
        //Database of media and patrons
        private SortedDictionary<uint, Media> mediaSD;
        private SortedDictionary<uint, Patron> patronSD;

        //stacks
        //each time a patron or media object is removed the id is stored on the stack. 
        //When adding new patrons or media items we will use numbers on the stack before adding new items.

        Stack patronIDs;
        Stack mediaIDs;
        uint mediaID;
        uint patronID;

        private Media m;
        DataBaseReadWrite db = new DataBaseReadWrite("patron.bin","media.bin");
        private string noPatron = "Error: No patron selected. Please click the patron's name.";
        private string noMedia = "Error: No media selected. Please click the name of the media to be checked in/out.";
        public Form1()
        {
            InitializeComponent();
            mediaSD = new SortedDictionary<uint, Media> { };
            patronSD = new SortedDictionary<uint, Patron> { };
            txtMediaType.SelectedIndex = 0;
            db.readCatalog(ref mediaSD);
            db.readPatron(ref patronSD);
            txtPatronItemsCheckedOut.SelectionMode = SelectionMode.MultiExtended;
            lblPatronDispName.Text = string.Empty;
			lblPatronID.Text = string.Empty;
            if (mediaSD.Count > 0)
			{
				Media.Setup(mediaSD.Keys.Last());
			}
			UpdateScreens();
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
            txtMediaID.Text = mediaID.ToString();
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
                    patronID = uint.Parse(patronIDs.Pop().ToString());
                }
            }
            txtPatronCardNum.Text = patronID.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void OnClosed(EventArgs e)
        {
            db.writeCatalog(mediaSD);
            db.writePatron(patronSD);
            db.writeIDs(patronIDs, mediaIDs);
            base.OnClosed(e);
        }
        /// <summary>
        /// Purpose: to display all patrons
        /// Nikki
        /// </summary>
        private void btnDisplayAllPatrons_Click(object sender, EventArgs e)
        {
            displayPatrons();
        }
        /// <summary>
        /// Purpose: helper for btnDisplayAllPatrons
        /// Nikki/Jon rewrite
        /// </summary>
        private void displayPatrons()
        {
            txtDisplayPatron.Items.Clear();
            foreach (KeyValuePair<uint, Patron> p in this.patronSD)
            {
                txtDisplayPatron.Items.Add(p.Value);
                txtDisplayPatron.DisplayMember = "_name";
            }
        }

        /// <summary>
        /// Purpose: helper for btnDisplayCheckedPerPatron
        /// </summary>
        /// <param name="P">Patron</param>
        private void displayChecked(Patron P)
        {
            String str = P._name + " has ";
            
            if (P._currentChecked.Count > 0)
            {
                str += "checked out:\n\n";
                foreach (KeyValuePair<uint, Media> m in P._currentChecked)
                {
                    str += "\t" + m.Value.Title + "\n";
                }
            }
            else
            {
                str += "nothing checked out.";
            }

            MessageBox.Show(str);
        }
        /// <summary>
        /// Purpose: to display all media items
        /// Nikki
        /// </summary>
        private void btnDisplayAllMedia_Click(object sender, EventArgs e)
        {
            displayMedia();
        }
        /// <summary>
        /// Purpose: helper for displaymedia button click
        /// Nikki, Jon rewrite
        /// </summary>
        private void displayMedia()
        {
            lstvwMediaList.Items.Clear();

            foreach (KeyValuePair<uint, Media> m in mediaSD)
            {
                    ListViewItem item = new ListViewItem(m.Value.Title);
                    if (m.Value.CheckedOut == true)
                    {
                        item.SubItems.Add(m.Value.Borrower._name);
                    }
                    else
                    {
                        item.SubItems.Add(" ");
                    }
                    item.SubItems.Add(m.Key.ToString());
                    lstvwMediaList.Items.Add(item);
            }

        }

        private void btnAddPatron_Click(object sender, EventArgs e)
        {
            saveNewPatron();
            setPatronID();

        }
        /// <summary>
        /// Purpose: save new patron once validated
        /// Nikki
        /// </summary>
        private void saveNewPatron()
        {
            if (Patron.validate(txtPatronName.Text, txtPatronAddress.Text, txtPatronCity.Text, txtPatronState.Text, txtPatronZip.Text, txtPatronPhone.Text, txtPatronCardNum.Text))
            {
                string combinedAddress = string.Concat(txtPatronAddress.Text, " ,", txtPatronCity.Text, ", ", txtPatronState.Text, ", ", txtPatronZip.Text);
              
                patronSD.Add(uint.Parse(txtPatronCardNum.Text), new Patron(txtPatronName.Text, uint.Parse(txtPatronCardNum.Text), combinedAddress, txtPatronPhone.Text, txtPatronDateofBirth.Value));
                MessageBox.Show("Patron added successfully!");
                UpdateScreens();//jon
                ClearAddPatronFields();
            }
        }
        private void btnAddMedia_Click(object sender, EventArgs e)
        {
            saveNewMedia();
            setMediaID();
        }
        /// <summary>
        /// Purpose: helper for button save media
        /// Nikki
        /// </summary>
        private void saveNewMedia()
        {
            
            if (validateMedia()) //validate GUI fields
            {
                if (txtMediaType.SelectedIndex == 1) //Adult Book
                {
                    m = new Media(txtMediaTitle.Text, txtMediaAuthor.Text, MediaType.ADULTBOOK,mediaID);
                    mediaSD.Add(mediaID, m);
                }
                if (txtMediaType.SelectedIndex == 2) //Child Book
                {
                    m = new Media(txtMediaTitle.Text,txtMediaAuthor.Text, MediaType.CHILDBOOK,mediaID);
                    mediaSD.Add(mediaID, m);
                }
                if (txtMediaType.SelectedIndex == 3) //DVD
                {
                    m = new Media(txtMediaTitle.Text, txtMediaAuthor.Text,MediaType.DVD,mediaID);
                    mediaSD.Add(mediaID, m);
                }
                if (txtMediaType.SelectedIndex == 4) //Video
                {
                    m = new Media(txtMediaType.Text,txtMediaAuthor.Text, MediaType.VIDEO,mediaID);
                    mediaSD.Add(mediaID, m);
                }
                MessageBox.Show("Media item '" +txtMediaTitle.Text+"' added successfully!");
                UpdateScreens(); //jon
                ClearAddMediaFields();
            }
           
        }
        /// <summary>
        /// Purpose: to validate media
        /// Nikki
        /// </summary>
        /// <returns>bool</returns>
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
        /// <summary>
        /// Purpose: exit the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Purpose: to remove patrons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Patron p;
            uint cardNumber;
            if (!uint.TryParse(txtRemovePatron.Text, out cardNumber))  //check if ID number is valid
            {
                MessageBox.Show("Please enter a valid library card number");
            }
            else
            {
                if (!patronSD.ContainsKey(cardNumber))//check if patron exists by ID number
                {
                    if (patronSD.Count == 0) //is patron database empty?
                    {
                        MessageBox.Show("No patrons to remove.");
                    }
                    else //patron not found
                    MessageBox.Show("No patron with such ID exists.");
                }
                else
                {
                    p = patronSD[cardNumber];
                    if (p._currentChecked.Count > 0) //check if patron has checkedout books
                    {
                        MessageBox.Show("This patron currently has books checked out, and cannot be removed.");
                    }
                    else 
                    {
                        patronIDs.Push(cardNumber); //mason
                        MessageBox.Show("Removed " + " " + p.ToString());
                        patronSD.Remove(cardNumber);
                        setPatronID();
                    }
					UpdateScreens();
					ClearRemovePatronFields();
                }
            }
        }
        /// <summary>
        /// Purpose: remove media
        /// Nikki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveMedia_Click(object sender, EventArgs e)
        {
            uint i;
            Media M;
            if (!uint.TryParse(txtMediaRemoveID.Text, out i)) //check if id number is valid
            {
                MessageBox.Show("Please enter a valid media ID number");
            }
            else if (mediaSD.ContainsKey(uint.Parse(txtMediaRemoveID.Text))) //find book by Id number
            {
                if (!mediaSD.TryGetValue(i, out M))
                {
                    if (mediaSD.Count == 0) //is database empty?
                    {
                        MessageBox.Show("No media items to remove.");
                    }
                    else
                        MessageBox.Show("No media with such ID exists.");
                }
                else
                {
					if (M.Borrower != Patron.None)
					{
         	           //check if book is checkedout before removing
         	           if (M.CheckedOut)
            	        {
        	                MessageBox.Show("This book is currently checked out, and cannot be removed.");
                	    }
          	          else
                	    {
                    	    MessageBox.Show(M.Title + " removed.");
                	        mediaSD.Remove(i);
                  	        mediaIDs.Push(i);//mason
                            setMediaID();
                    	}
					}				
                }
            }
        }

        private void btnClearGUI_Click(object sender, EventArgs e)
        {
            ClearMainGUI();
        }

        /// <summary>
        /// Clears everything on the main page
        /// Nikki, Jon
        /// </summary>
        private void ClearMainGUI()
        {
            dateTimePicker.Value = DateTime.Today;
            lblPatronDispName.Text = string.Empty;
			lblPatronID.Text = string.Empty;
            txtDisplayPatron.SelectedIndex = -1;
            UpdateScreens();
        }
		/// <summary>
		/// Purpose: to display overdue media per patron
        /// Nikki
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btnDisplayOverdue_Click(object sender, EventArgs e)
        {
            displayOverdueMedia.Clear(); 
            foreach (KeyValuePair<uint, Media> mm in this.mediaSD)
            {
                if(mm.Value.Overdue(dateTimeOverdue.Value))
                {
                    displayOverdueMedia.Text += mm.Value.ToString();
                }
            }  
        }

        /// <summary>
        /// Updates the patron name label
        /// Jon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDisplayPatron_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtDisplayPatron.SelectedIndex != -1)
            {
                Patron patron = txtDisplayPatron.SelectedItem as Patron;
                lblPatronDispName.Text = patron._name;
				lblPatronID.Text = "ID: " + patron.CardNumber;
                UpdatePatronItemsCheckedOut(patron);
            }
        }

        /// <summary>
        /// Fills the list box with the items the patron currently has checked out
        /// Jon
        /// </summary>
        /// <param name="patron"></param>
        private void UpdatePatronItemsCheckedOut(Patron patron)
        {
            txtPatronItemsCheckedOut.Items.Clear();

            foreach (KeyValuePair<uint, Media> m in patron._currentChecked)
            {
                Media media = m.Value;
                txtPatronItemsCheckedOut.Items.Add(media);
                txtPatronItemsCheckedOut.DisplayMember = "Title";
            }

            if (txtPatronItemsCheckedOut.Items.Count > 0)
            {
                txtPatronItemsCheckedOut.SelectedIndex = 0;
            }
            
            CheckCheckInButton();
        }
        /// <summary>
        /// Purpose: checkout media
        /// Nikki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            CheckOutMedia();            
        }
        /// <summary>
        /// Purpose: check in media
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            CheckInMedia();
            displayMedia();
        }

        /// <summary>
        /// Checks out media -helper for btn click
        /// Nikki, Jon
        /// </summary>
        private void CheckOutMedia()
        {
            if (txtDisplayPatron.SelectedIndex == -1) //check if patron selected
            {
                MessageBox.Show(noPatron);
            }

            if (lstvwMediaList.SelectedItems.Count <= 0) //check if media selected
            {
                MessageBox.Show(noMedia);
            }
            else
            {
                Patron p = (Patron)txtDisplayPatron.SelectedItem;

                //Check to see if patron has overdue books
                if (!p.overdueBooks(dateTimePicker.Value))
                {
                    bool success = true;

                    // For multiple check outs, check that each one is successful
                    foreach (ListViewItem item in lstvwMediaList.SelectedItems)
                    {
                        if (success)
                        {
                            Media media = mediaSD[(uint)Convert.ToInt32(item.SubItems[clmID.Index].Text)];

                            if (p.allowed(media))//is checkout allowed based on age restrictions?
                            {
                                success = media.CheckOut(p, dateTimePicker.Value) ? true : false;
                            }
                            else
                            {
                                success = false;
                            }
                        }
                    }

                    // Print results
                    if (success)
                    {
                        MessageBox.Show("Check out successful!");
                    }
                    else
                    {
                        MessageBox.Show("Check out failed!");
                    }                   

                    // Update info on main screen
                    UpdatePatronItemsCheckedOut(p);
                    displayMedia();
                    CheckCheckInButton();
                }
            }
        }

        /// <summary>
        /// Checks in the media - helper for btn click
        /// Nikki, Jon
        /// </summary>
        private void CheckInMedia()
        {
            if (txtDisplayPatron.SelectedIndex == -1) //check if patron selected
            {
                MessageBox.Show(noPatron);
            }
            if (txtPatronItemsCheckedOut.SelectedIndex == -1) //check if media selected
            {
                MessageBox.Show(noMedia);
            }
            else
            {
                Patron patron = txtDisplayPatron.SelectedItem as Patron;
                
                bool success = true;

                // For multiple check ins, check that each is successful
                foreach (object o in txtPatronItemsCheckedOut.SelectedItems)
                {
                    if (success)
                    {
                        Media media = o as Media;

                        if (patron._currentChecked.ContainsKey(media.ID))
                        {
                            success = mediaSD[media.ID].CheckIn() ? true : false;
                            patronSD[patron.CardNumber].removeMedia(media.ID);
                        }
                    }
                }

                // Print results
                if (success)
                {
                    MessageBox.Show("Check in successful!");
                }
                else
                {
                    MessageBox.Show("Check in failed!");
                }

                // Update info on main screen
                UpdatePatronItemsCheckedOut(patron);
                displayMedia();
                CheckCheckInButton();
            }
        }

        private void lstvwMediaList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstvwMediaListChange();
        }        

        /// <summary>
        /// Handles when index selections change on the media ListView
        /// </summary>
        private void lstvwMediaListChange()
        {
            if (lstvwMediaList.SelectedItems.Count > 0)
            {
                bool selectionNotCheckedOut = true;

                // Check to see if any of the selected items are already checked out
                foreach (ListViewItem item in lstvwMediaList.SelectedItems)
                {
                    if (selectionNotCheckedOut)
                    {
                        Media media = mediaSD[uint.Parse(item.SubItems[clmID.Index].Text)];
                        //Media media = mediaSD[(uint)Convert.ToInt32(item.SubItems[clmID.Index].Text)];
                        
                        selectionNotCheckedOut = media.CheckedOut ? false : true;
                    }
                }

                // Toggle button if user can check media out
                if (selectionNotCheckedOut && txtDisplayPatron.SelectedItems.Count > 0)
                {
                    btnCheckOut.Enabled = true;
                }
                else
                {
                    btnCheckOut.Enabled = false;
                }
            }
        }

        private void txtPatronItemsCheckedOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckCheckInButton();
        }

        /// <summary>
        /// Updates all the text boxes on main
        /// </summary>
        private void UpdateScreens()
        {
            if (txtDisplayPatron.SelectedIndex != -1)
            {
                UpdatePatronItemsCheckedOut(txtDisplayPatron.SelectedItem as Patron);
            }
            else
            {
                txtPatronItemsCheckedOut.Items.Clear();
            }
            if (mediaSD.Count >0)
            {
                displayMedia();
            }
            if (patronSD.Count > 0)
            {
                displayPatrons();
            }
            if (txtDisplayPatron.SelectedItems.Count == 0)
            {
                btnCheckOut.Enabled = false;
            }

            CheckCheckInButton();
        }

        /// <summary>
        /// Clears all boxes related to adding media
        /// </summary>
        private void ClearAddMediaFields()
        {
            txtMediaType.SelectedIndex = 0;
            txtMediaAuthor.Text = string.Empty;
            txtMediaTitle.Text = string.Empty;
        }

        /// <summary>
        /// Clears all boxes related to adding patrons
        /// </summary>
        private void ClearAddPatronFields()
        {
            txtPatronName.Text = string.Empty;
            txtPatronCardNum.Text = string.Empty;
            txtPatronPhone.Text = string.Empty;
            txtPatronAddress.Text = string.Empty;
            txtPatronCity.Text = string.Empty;
            txtPatronState.Text = string.Empty;
            txtPatronZip.Text = string.Empty;
            txtPatronDateofBirth.Value = DateTime.Today;
        }

        /// <summary>
        /// Clears all boxes related to removing patrons
        /// </summary>
        private void ClearRemovePatronFields()
        {
            txtRemovePatron.Text = string.Empty;
        }

        /// <summary>
        /// Clears all boxes related to removing media
        /// </summary>
        private void ClearRemoveMediaFields()
        {
            txtMediaRemoveID.Text = string.Empty;
        }

        /// <summary>
        /// Determines whether or not to disable the CheckIn button
        /// </summary>
        private void CheckCheckInButton()
        {
            if (txtPatronItemsCheckedOut.SelectedItems.Count > 0)
            {
                btnCheckIn.Enabled = true;
            }
            else
            {
                btnCheckIn.Enabled = false;
            }
        }
    }
}
