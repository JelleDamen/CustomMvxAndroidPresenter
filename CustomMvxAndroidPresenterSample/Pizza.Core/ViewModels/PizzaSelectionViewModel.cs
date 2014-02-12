using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;


namespace Pizza.Core
{
	public class PizzaSelectionViewModel : MvxViewModel
	{
		public IMvxCommand FClickCommand
		{
			get{ 
				return new MvxCommand (() => {
					ShowViewModel<PizzaFViewModel>();
				});
			}
		}

		public IMvxCommand MClickCommand
		{
			get{ 
				return new MvxCommand (() => {
					ShowViewModel<PizzaMViewModel>();
				});
			}
		}

		public IMvxCommand PClickCommand
		{
			get{ 
				return new MvxCommand (() => {
					ShowViewModel<PizzaPViewModel>();
				});
			}
		}
	}
}

