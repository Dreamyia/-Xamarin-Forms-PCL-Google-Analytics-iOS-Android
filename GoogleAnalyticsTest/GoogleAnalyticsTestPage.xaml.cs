using Xamarin.Forms;
using System;
using GoogleAnalyticsTest.Droid;

namespace GoogleAnalyticsTest
{
	
	public partial class GoogleAnalyticsTestPage : ContentPage
	{
		private int counter = 0;

		public GoogleAnalyticsTestPage()
		{
			//will show up page name depending on what platform 
			//Android 
			if (Device.OS == TargetPlatform.Android)
			{
				//Track Page
				GASCall.Track_App_Page("Android HomePage");
			}
			//or iOS
			else {
				//Track Page
				GASCall.Track_App_Page("iOS HomePage");
			}

			InitializeComponent();



		}
		//button click to call events
		public void OnClickButtonGoogleEventMethod(object sender, EventArgs args)
		{
			GoogleAnalyticsEvents(GAEventCategory.CountButton, "Button Pressed "+ counter++);
		}

		//sending event to google analytics
		private void GoogleAnalyticsEvents( string Category, string EventToTrack) { 
				GASCall.Track_App_Event(Category, EventToTrack);

		}
	}
}
