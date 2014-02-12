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
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore.Plugins;

using System.Reflection;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using System.Globalization;
using System.Threading;
using Android.Content.Res;
using Pizza.Core;

namespace Pizza.Droid.UI {
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override Cirrious.MvvmCross.Droid.Views.IMvxAndroidViewPresenter CreateViewPresenter ()
		{
			var customPresenter = new CustomPresenter();
			Mvx.RegisterSingleton<ICustomPresenter>(customPresenter);
			return customPresenter;
		}

	}
}