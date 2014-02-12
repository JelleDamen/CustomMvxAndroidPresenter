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
using Cirrious.CrossCore;
using Pizza.Core;
using Android.Support.V4.Widget;

namespace Pizza.Droid.UI
{
	[Activity (Label = "HostView")]			
	public class HostView : MvxHostFragmentActivity
	{
		public HostView () : base (new PresenterRegistrationList()
			{
				new PresenterRegistration(typeof(PizzaSelectionViewModel), Resource.Id.content2region),
				new PresenterRegistration(typeof(PizzaFViewModel), Resource.Id.content1region),
				new PresenterRegistration(typeof(PizzaMViewModel), Resource.Id.content1region),
				new PresenterRegistration(typeof(PizzaPViewModel), Resource.Id.content1region)
			})
		{

		}

		protected override void OnCreate (Bundle bundle)
		{
			SetContentView (Resource.Layout.view_host);

			base.OnCreate (bundle);
		}

		public override void Show (Cirrious.MvvmCross.ViewModels.MvxViewModelRequest request)
		{
			FragmentHostHelper.Show (request, this);
		}

	}
}

