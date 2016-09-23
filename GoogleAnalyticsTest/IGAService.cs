using System;
namespace GoogleAnalyticsTest
{
	public interface IGAService
	{
	    void Track_App_Page(String PageNameToTrack);

		void Track_App_Event(String GAEventCategory, String EventToTrack);

		void Track_App_Exception(String ExceptionMessageToTrack, Boolean isFatalException);
	}
}