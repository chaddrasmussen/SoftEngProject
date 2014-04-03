using System;
namespace Library
{
    [Serializable]
	sealed class Adult : Media
	{
		// ********************************* Constants ***************************************

		private const uint ADULT_LOAN_TIME = 14;

		// ******************************* Constructors **************************************

		private Adult() { }

		public Adult(string title, uint numberOfCopies)
			: base(title, ADULT_LOAN_TIME, numberOfCopies)
		{

		}

		// ***********************************************************************************
	}
}
