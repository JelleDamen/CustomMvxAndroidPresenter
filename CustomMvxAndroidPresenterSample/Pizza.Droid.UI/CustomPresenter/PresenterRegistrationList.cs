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
	public class PresenterRegistrationList : List<PresenterRegistration>
	{
		public bool ContainsViewModel(Type viewModel)
		{
			return this.FirstOrDefault (i => i.ViewModel == viewModel) != null;
		}

		public int GetRegionId(Type viewModel)
		{
			var result = this.FirstOrDefault (i => i.ViewModel == viewModel);
			if (result == null)
				throw new ArgumentException (string.Format ("Unable to resolve regionId for provided viewmodel: {0}", viewModel));
			//success
			return result.Region;
		}
	}
}

