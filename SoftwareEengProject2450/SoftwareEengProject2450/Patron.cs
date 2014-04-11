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
        public static string nameDisplay = "\nName: ";
        public static string cardNumberDisplay = "\nCard Number";

        /// <summary>
        /// Purpose: to validate patron info from GUI before saving new object
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="address">string</param>
        /// <param name="city">string</param>
        /// <param name="state">string</param>
        /// <param name="zip">string</param>
        /// <param name="phone">string</param>
        /// <param name="cardNumber">string</param>
        /// <returns></returns>
        public static bool validate(string name, string address, string city, string state, string zip, string phone, string cardNumber )
        {
            validator = new Regex(@"((\d{1,6}\-\d{1,6})|(\d{1,6}\\\d{1,6})|(\d{1,6})(\/)(\d{1,6})|(\w{1}\-?\d{1,6})|(\w{1}\s\d{1,6})|((P\.?O\.?\s)((BOX)|(Box))(\s\d{1,6}))|((([R]{2})|([H][C]))(\s\d{1,6}\s)((BOX)|(Box))(\s\d{1,6}))?)$");
           if (!validator.Match(address).Success)
           {
               MessageBox.Show(address+" was an invalid entry for address. Please try again.");
               return false;
           }
           validator = new Regex(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$");
            if (!validator.Match(city).Success)
            {
                MessageBox.Show(city + "was an invalid entry for city. Please try again.");
                return false;
            }
            validator = new Regex("[A-Z]{2}");
            if (!validator.Match(state).Success)
            {
                MessageBox.Show(state + "was an invalid entry for state. Please try again.");
                return false;
            }
            validator = new Regex(@"^\d{5}$");
            if (!validator.Match(state).Success)
            {
                MessageBox.Show(zip + "was an invalid entry for zip code. Please try again.");
                return false;
            }
            validator = new Regex(@"^(?:\([2-9]\d{2}\)\ ?|[2-9]\d{2}(?:\-?|\ ?))[2-9]\d{2}[- ]?\d{4}$");
            if (!validator.Match(phone).Success)
            {
                MessageBox.Show(phone + "was an invalid entry for phone number. Please try again.");
                return false;
            }
            validator = new Regex("[0-9]+");
            if (!validator.Match(cardNumber).Success)
            {
                MessageBox.Show(cardNumber + "was an invalid entry for card number. Please try again.");
                return false;
            }
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
            return String.Format(nameDisplay + _name + cardNumberDisplay + CardNumber);
        }

    }

}
