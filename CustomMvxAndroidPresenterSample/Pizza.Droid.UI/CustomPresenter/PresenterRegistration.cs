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

namespace Pizza.Droid.UI
{
	public class PresenterRegistration
	{
		public PresenterRegistration (Type viewModel, int region)
		{
			ViewModel = viewModel;
			Region = region;
		}

		public PresenterRegistration (Type viewModel)
		{
			ViewModel = viewModel;
		}

		public Type ViewModel { get; set; }
		public int Region { get; set; }
	}
}

