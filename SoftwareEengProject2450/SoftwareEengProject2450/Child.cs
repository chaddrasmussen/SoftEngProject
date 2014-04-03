
namespace Library
{
	sealed class Child : MediaObject
	{
		// ********************************* Constants ***************************************

		private const uint CHILD_LOAN_TIME = 7;

		// ******************************* Constructors **************************************

		private Child() { }

		public Child(string title, uint numberOfCopies)
			: base(title, CHILD_LOAN_TIME, numberOfCopies)
		{

		}

		// **********************************************************************************


	}
}
