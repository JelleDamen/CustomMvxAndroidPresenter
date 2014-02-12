using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.CrossCore;


namespace Pizza.Droid.UI
{
	[Activity (Label = "Pizza", NoHistory=true, MainLauncher = true, Theme = "@android:style/Theme.Holo.Light.NoActionBar")]			
	public class Bootstrap : MvxSplashScreenActivity
	{

	}
}

