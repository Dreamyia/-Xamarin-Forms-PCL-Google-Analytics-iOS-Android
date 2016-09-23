§using System;
using Xamarin.Forms;

namespace GoogleAnalyticsTest.Droid
{
	// Google Analytics Services access point
	public static class GASConnect
	{
		public static void Track_App_Page(String PageNameToTrack)
		{
			DependencyService.Get<IGAService>().Track_App_Page(PageNameToTrack);

		}	                                                   
		public static void Track_App_Event(String GAEventCategory, String EventToTrack)
		{
			DependencyService.Get<IGAService>().Track_App_Event(GAEventCategory, EventToTrack);
		}

		public static void Track_App_Exception(String ExceptionMessageToTrack, Boolean isFatalException)
		{
			DependencyService.Get<IGAService>().Track_App_Exception(ExceptionMessageToTrack, isFatalException);
		}

	}
}
