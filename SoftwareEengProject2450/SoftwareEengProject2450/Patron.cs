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

        public SortedDictionary<uint, MediaObject> _currentChecked { get; set; }

        public Patron()
        {
            _name = "";
            _address = "";
            _address = "";
            _age = 0;
            _overdueMedia = false;
            _currentChecked = new SortedDictionary<uint, MediaObject>();
            _maxCheckouts = 0;

        }
        public Patron(string name, string address, string phoneNumber, uint age, bool fines, int numChecked)
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
            _overdueMedia = fines;
            _currentChecked = new SortedDictionary<uint, MediaObject>();
        }
        /// <summary>
        /// Purpose: to return number of checked books
        /// </summary>
        /// <returns>int</returns>
        public int getNumChecked()
        {
            return _currentChecked.Count;
        }

        public virtual void addMedia(MediaObject media, uint ID)
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
        
        public virtual void removeMedia(MediaObject media, uint ID)
        {
            if (_currentChecked.Count == 0)
            {
                MessageBox.Show(noneChecked);
            }
            _currentChecked.Remove(ID);
        }
        
        public bool Fines
        {
            //if media.overdue = true, fines = true;
            get { return _overdueMedia; }
            set { _overdueMedia = value; }
        }


    }

}
