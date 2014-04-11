using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
namespace Library
{
    /// <summary>
    /// Class Patron
    /// </summary>
    [Serializable]
    public class Patron : object
    {
        public string _name { get; set; }
        public string _address { get; set; }
        public string _phoneNumber { get; set; }
        private uint _cardNumber;
        public uint CardNumber { get { return _cardNumber; } }
        private DateTime _birthday;
        static Regex validator;
        public int getAge()
        {
            int _age = 0;
            return _age = ((DateTime.Now.Year - _birthday.Year) * 372 + 
                (DateTime.Now.Month - _birthday.Month) * 31 + (DateTime.Now.Day - _birthday.Day)) / 372; 
        }
        public uint _maxCheckouts { get; set; }
        public bool _overdueMedia { get; set; }
        private string noneChecked = "This patron does not have any checked-out books to be removed.";
        public static string name = "\nName: ";
        public static string address = "\nAddress: ";
        public static string age = "\nAge: ";
        public static string cardNumber = "\nCard Number";
        public static string overdueMedia = "\nOverdue Media? ";
        public static string maxCheckouts = "\nMaximum allowed checkouts: ";
        public static string phoneNumber = "\nPhone Number: ";
        public static string newLine = "\n";
        
        public static bool validate(string name, string address, string city, string state, string zip, string phone, string cardNumber )
        {
           // validator = new Regex(@"[A-Z|a-z|0-9|.|,|-|#|]");

            return true;
        }
        public SortedDictionary<uint, Media> _currentChecked { get; set; }

        public Patron()
        {
            _name = "";
            _address = "";
            _birthday = DateTime.Today;
            _phoneNumber = "";
            _overdueMedia = false;
            _currentChecked = new SortedDictionary<uint, Media>();
            _maxCheckouts = 0;
            _cardNumber = 0;
        }
        public Patron(string name, uint cardNumber, string address, string phoneNumber, DateTime birthday)
        {
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _birthday = birthday;
            if (getAge() >= 18)
            { 
                _maxCheckouts = 6; 
            }
            else
            { 
                _maxCheckouts = 3; 
            }
            _overdueMedia = false;
            _cardNumber = cardNumber;
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
            return String.Format(name + _name + cardNumber + _cardNumber + address + _address + phoneNumber + _phoneNumber + age + _birthday.ToString() + overdueMedia +
                _overdueMedia.ToString() + maxCheckouts + _maxCheckouts.ToString() + newLine);
        }

    }

}
