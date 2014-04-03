using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    [Serializable]
	abstract class MediaObject
	{		

		// ********************************* Variables ***************************************

		private Patron _borrower;

		// ******************************** Properties ***************************************

		public static uint UniqueTitleCount { get; private set; }

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

		public MediaObject() { }

		public MediaObject(string title, uint loanTime, uint numberOfCopies)
		{
			Title = title;
			LoanTime = loanTime;
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
				throw new Exception("Available copies are already at their max");
			}
		}

		// ***********************************************************************************
	}
}
