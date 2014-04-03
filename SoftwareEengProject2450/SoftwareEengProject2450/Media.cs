namespace Library
{
	abstract class Media : MediaObject
	{
		// ******************************* Constructors **************************************

		public Media() { }

		public Media(string title, uint loanTime, uint numberOfCopies)
			: base(title, loanTime, numberOfCopies)
		{

		}

		// **********************************************************************************
	}
}
