using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public enum MediaType { DVD, VIDEO, BOOK };
    [Serializable]
	public class Media
	{
        
		// ********************************* Variables ***************************************
        //enum media type
		private Patron _borrower;
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

		public static uint UniqueTitleCount { get; private set; }

        public DateTime dateCheckedOut { get; set; }
		public uint LoanTime { get; private set; }
		public uint NumberOfCopies { get; private set; }
		public uint AvailableCopies { get; private set; }
		public uint ID { get; private set; }
		public string Title { get; private set; }
		public bool CheckedOut { get; private set; }
		public bool Overdue { get; set; }
       
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

		public Media(string title, uint numberOfCopies)
		{
			Title = title;
            LoanTime = 0; 
			CheckedOut = false;
			NumberOfCopies = numberOfCopies;
			AvailableCopies = numberOfCopies;
			ID = ++ID;
			++UniqueTitleCount;
		}

		// ********************************* Methods *****************************************

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
                Title + _checkedOut + CheckedOut.ToString() + _overdue + Overdue.ToString() + _newLine);
        }
	}
}
