using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;

namespace Library
{
    /// <summary>
    /// Class Patron
    /// </summary>
    [Serializable]
    class Patron : object
    {
        public string _name { get; set; }
        public string _address { get; set; }
        public string _phoneNumber { get; set; }
        public uint _age { get; set; }
        public uint _maxCheckouts { get; set; }
        public bool _overdueMedia { get; set; }
        private string noneChecked = "This patron does not have any checked-out books to be removed.";
        public static string name = "\nName: ";
        public static string address = "\nAddress: ";
        public static string age = "\nAge: ";
        public static string overdueMedia = "\nOverdue Media? ";
        public static string maxCheckouts = "\nMaximum allowed checkouts: ";
        public static string phoneNumber = "\nPhone Number: ";
        public static string newLine = "\n";
       
        public SortedDictionary<uint, Media> _currentChecked { get; set; }

        public Patron()
        {
            _name = "";
            _address = "";
            _age = 0;
            _phoneNumber = "";
            _overdueMedia = false;
            _currentChecked = new SortedDictionary<uint, Media>();
            _maxCheckouts = 0;

        }
        public Patron(string name, string address, string phoneNumber, uint age, bool overdue, int numChecked)
        {
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _age = age;
            if(age >= 18)
            { 
                _maxCheckouts = 6; 
            }
            else
            { 
                _maxCheckouts = 3; 
            }
            _overdueMedia = overdue;
            _currentChecked = new SortedDictionary<uint, Media>();
        }
        /// <summary>
        /// Purpose: to return number of checked books
        /// </summary>
        /// <returns>int</returns>
        public int getNumChecked()
        {
            return _currentChecked.Count;
        }

        public virtual void addMedia(Media media, uint ID)
        {
            if(_currentChecked.Count <= _maxCheckouts)
            {
                _currentChecked.Add(ID, media);
            }
            else
            {
                MessageBox.Show("You have reached the maximum(" + _maxCheckouts + ") number of checkouts allowed\n");
            }
        }
        
        public virtual void removeMedia(Media media, uint ID)
        {
            if (_currentChecked.Count == 0)
            {
                MessageBox.Show(noneChecked);
            }
            _currentChecked.Remove(ID);
        }
        
        public bool Overdue
        {
            //if media.overdue = true, fines = true;
            get { return _overdueMedia; }
            set { _overdueMedia = value; }
        }
        public override string ToString()
        {
            return String.Format(name + _name + address + _address + phoneNumber + _phoneNumber + age + _age.ToString() + overdueMedia +
                _overdueMedia.ToString() + maxCheckouts + _maxCheckouts.ToString() + newLine);
        }

    }

}
