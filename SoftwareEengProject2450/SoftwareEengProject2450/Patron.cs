using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;

namespace Library
{
    /// <summary>
    /// Class Patron
    /// </summary>
    abstract class Patron : object
    {
        protected string _name;
        protected string _address;
        protected string _phoneNumber;
        protected uint _age;
        protected bool _overdueMedia;
        private string noneChecked = "This patron does not have any checked-out books to be removed.";

        protected SortedDictionary<uint, MediaObject> _currentChecked;

        public Patron()
        {
            _name = "";
            _address = "";
            _address = "";
            _age = 0;
            _overdueMedia = false;
            _currentChecked = new SortedDictionary<uint, MediaObject>();

        }
        public Patron(string name, string address, string phoneNumber, uint age, bool fines, int numChecked)
        {
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _age = age;
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
    /// <summary>
    /// Adult Patron
    /// </summary>
    sealed class Adult : Patron
    {
        private string maxChecked = "This patron has already checked out the maximum number of items, ";

        private const int MIN_AGE = 18;
        private const int MAX_CHECKED = 6;
        public Adult()
            : base()
        {

        }
        public Adult(string name, string address, string phoneNumber, uint age, bool fines, int numChecked)
            : base()
        {

        }
        public override void addMedia(MediaObject media, uint ID)
        {
            if (_currentChecked.Count < MAX_CHECKED)
            {
                _currentChecked.Add(ID, media);
            }
            else
            {
                MessageBox.Show(maxChecked + MAX_CHECKED + ".");
            }
        }


    }
    /// <summary>
    /// Child Patron
    /// </summary>
    sealed class Child : Patron
    {
        private const int MAX_AGE = 18;
        private const int MAX_CHECKED = 3;
        public Child()
            : base()
        {

        }
        public Child(string name, string address, string phoneNumber, uint age, bool fines, int numChecked)
            : base()
        {

        }
        public override void addMedia(MediaObject media, uint ID)
        {
            if (_currentChecked.Count < MAX_CHECKED)
            {
                _currentChecked.Add(ID, media);
            }
            else
            {
                MessageBox.Show("This patron has already checked out the maximum number of items, " + MAX_CHECKED + ".");
            }
        }
    }
    public class MediaObject
    {

    }
}
