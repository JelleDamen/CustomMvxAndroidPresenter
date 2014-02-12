using System;
using Cirrious.MvvmCross.ViewModels;

namespace Pizza.Core
{
	public class HostViewModel : MvxViewModel
	{

		public override void Start ()
		{
			base.Start ();

			ShowViewModel<PizzaSelectionViewModel> ();
		}
		
	}
}

