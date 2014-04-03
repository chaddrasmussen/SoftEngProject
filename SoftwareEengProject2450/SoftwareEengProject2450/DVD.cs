using System;
namespace Library
{
    [Serializable]
	sealed class DVD : Media
	{
		// ********************************* Constants ***************************************

		private const uint DVD_LOAN_TIME = 2;

		// ******************************* Constructors **************************************

		private DVD() { }

		public DVD(string title, uint numberOfCopies)
			: base(title, DVD_LOAN_TIME, numberOfCopies)
		{

		}

		// **********************************************************************************
	}
}
