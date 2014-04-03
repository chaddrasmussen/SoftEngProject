using System;
namespace Library
{
    [Serializable]
	class VideoTape : Media
	{
		// ********************************* Constants ***************************************

		private const uint VIDEOTAPE_LOAN_TIME = 3;

		// ******************************* Constructors **************************************

		private VideoTape() { }

		public VideoTape(string title, uint numberOfCopies)
			: base(title, VIDEOTAPE_LOAN_TIME, numberOfCopies)
		{

		}

		// **********************************************************************************
	}
}
