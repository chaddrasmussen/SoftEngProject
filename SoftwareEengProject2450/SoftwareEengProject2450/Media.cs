using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public enum MediaType { CHILDBOOK, ADULTBOOK, DVD, VIDEO };
    [Serializable]
	public class Media
	{
        
		// ********************************* Variables ***************************************
        //enum media type
		
        public static string _dateCheckedOut = "\nDate Checked Out: ";
        public static string _loanTime = "\nLoan Tine: ";
        public static string _numCopies = "\nNumber of Copies: ";
        public static string _availableCopies = "\nAvailable Copies";
        public static string _id = "\nID Number: ";
        public static string _title = "\nTitle: ";
        public static string _checkedOut = "\nCurrently Checked Out? ";
        public static string _overdue = "\nOverdue? ";
        public static string _newline = "\n";
        public static string _patronBorrower = "\nBorrower: ";
		// ******************************** Properties ***************************************
        private Patron _borrower;
        //private TimeSpan loanTime;
		public static uint UniqueTitleCount { get; private set; }
        private MediaType mType;
        public MediaType Mtype {get { return mType; }}
        public DateTime dateCheckedOut { get; set; }
        private uint loanTime;
		public uint NumberOfCopies { get; private set; }
		public uint AvailableCopies { get; private set; }
		public uint ID { get; private set; }
		public string Title { get; private set; }
		public bool CheckedOut { get; private set; }
		public bool Overdue { get; set; }
        private const uint MAX_CHILD_LOAN = 7;
        private const uint MAX_ADULT_LOAN = 14;
        private const uint MAX_DVD_LOAN = 2;
        private const uint MAX_VIDEO_LOAN = 3;
		public Patron Borrower
		{
			get { return _borrower; }
			private set 
			{
  				if (value != null)
				{
					_borrower = value;
				}
				else
				{
					throw new Exception("Null reference, Patron was null");
				}
			}
		}

		// ******************************* Constructors **************************************

		public Media() { }

		public Media(string title, uint numberOfCopies, MediaType mType)
		{
			Title = title;
            setLoanTime(mType);
			CheckedOut = false;
			NumberOfCopies = numberOfCopies;
			AvailableCopies = numberOfCopies;
			ID = ++ID;
			++UniqueTitleCount;
            this.mType = mType;
		}

		// ********************************* Methods *****************************************
        public void setLoanTime(MediaType mt)
        {
            if (mt == MediaType.CHILDBOOK)
            {
                loanTime = MAX_CHILD_LOAN;
            }
            if (mt == MediaType.ADULTBOOK)
            {
                loanTime = MAX_ADULT_LOAN;
            }
            if (mt == MediaType.DVD)
            {
                loanTime = MAX_DVD_LOAN;
            }
            if (mt == MediaType.VIDEO)
            {
                loanTime = MAX_VIDEO_LOAN;
            }
        }
        public uint getLoanTime()
        {
            return loanTime;
        }
		/// <summary>
		/// Checks the book out, assigns borrower
		/// </summary>
		/// <param name="borrower">Patron borrowing the media</param>
		public void CheckOut(Patron borrower)
		{
			if (AvailableCopies > 0)
			{
				CheckedOut = true;
				Borrower = borrower;
				--AvailableCopies;
			}
		}

		// *********************************************************

		/// <summary>
		/// Checks the book in, releases borrower
		/// </summary>
		public void CheckIn()
		{
			if (AvailableCopies < NumberOfCopies)
			{
				CheckedOut = false;
				Borrower = null;//Patron.None;
				++AvailableCopies;
			}
			else
			{
				throw new Exception("Available copies are already at their max.");
			}
		}

		// ***********************************************************************************

        public override string ToString()
        {
            return String.Format(_patronBorrower+ _borrower._name + _id + ID + _dateCheckedOut + dateCheckedOut.ToString() + _loanTime +
                LoanTime.ToString()  + _numCopies + NumberOfCopies.ToString() + _availableCopies + AvailableCopies.ToString() + _title + 
                Title + _checkedOut + CheckedOut.ToString() + _overdue + Overdue.ToString() +"\n");
        }
	}
}
