namespace Library
{
	sealed class Adult : MediaObject
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
