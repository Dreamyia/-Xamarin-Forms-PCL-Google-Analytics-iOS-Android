using System;
using Foundation;
using Google.Analytics;
using Xamarin.Forms;

[assembly: Dependency(typeof(GoogleAnalyticsTest.iOS.GAService))]
namespace GoogleAnalyticsTest.iOS
{
	public class GAService : IGAService
	{
		//replace with your tracking id https://analytics.google.com/
		public string TrackingId = "UA-84011627-1";
		public ITracker Tracker;
		const string AllowTrackingKey = "AllowTracking";

		#region Instantition...
		private static GAService thisRef;
		public GAService()
		{
			// no code req'd
		}

		public static GAService GetGASInstance()
		{
			if (thisRef == null)
				// it's ok, we can call this constructor
				thisRef = new GAService();
			return thisRef;
		}
		#endregion

		public void Initialize_NativeGAS()
		{
			var optionsDict = NSDictionary.FromObjectAndKey(new NSString("YES"), new NSString(AllowTrackingKey));
			NSUserDefaults.StandardUserDefaults.RegisterDefaults(optionsDict);

			Gai.SharedInstance.OptOut = !NSUserDefaults.StandardUserDefaults.BoolForKey(AllowTrackingKey);

			Gai.SharedInstance.DispatchInterval = 10;
			Gai.SharedInstance.TrackUncaughtExceptions = true;

			Tracker = Gai.SharedInstance.GetTracker("Test App", TrackingId);
		}

		public void Track_App_Page(String PageNameToTrack)
		{
			Gai.SharedInstance.DefaultTracker.Set(GaiConstants.ScreenName, PageNameToTrack);
			Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateScreenView().Build());
		}

		public void Track_App_Event(String GAEventCategory, String EventToTrack)
		{
			Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateEvent(GAEventCategory, EventToTrack, "AppEvent", null).Build());
			Gai.SharedInstance.Dispatch(); // Manually dispatch the event immediately
		}

		public void Track_App_Exception(String ExceptionMessageToTrack, Boolean isFatalException)
		{
			Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateException(ExceptionMessageToTrack, isFatalException).Build());
		}
	}
}