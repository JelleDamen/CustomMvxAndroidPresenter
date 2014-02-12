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
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using Pizza.Core;

namespace Pizza.Droid.UI
{
	public abstract class MvxHostFragmentActivity : MvxFragmentActivity, IFragmentHost
	{
		PresenterRegistrationList _presenterRegistrationList;

		public MvxHostFragmentActivity (PresenterRegistrationList presenterRegistrationList)
		{
			_presenterRegistrationList = presenterRegistrationList;
		}

		protected override void OnCreate (Bundle bundle)
		{
			var presenter = Mvx.Resolve<ICustomPresenter> ();
			presenter.RegisterHost (this);
			base.OnCreate (bundle);
		}

		public virtual void Show (MvxViewModelRequest request)
		{
			//TODO: keep track on wich viewmodel is already shown on this host. 
		}

		public virtual void OnFragmentResumed (IMvxViewModel viewModel)
		{

		}

		/// <summary>
		/// Gets the current fragment manager.
		/// </summary>
		/// <value>The fragment manager.</value>
		public virtual Android.Support.V4.App.FragmentManager CurrentFragmentManager {
			get {
				return this.SupportFragmentManager;
			}
		}

		/// <summary>
		/// Gets the supported view models with the corresponding region layout
		/// </summary>
		/// <value>The supported view models.</value>
		public virtual PresenterRegistrationList SupportedPresenterRegistrations {
			get {
				return _presenterRegistrationList;
			}
		}

		/// <summary>
		/// Raises when the transaction gets created.
		/// </summary>
		/// <param name="transaction">Transaction.</param>
		public virtual void OnTransactionCreated (MvxViewModelRequest request, Android.Support.V4.App.FragmentTransaction transaction)
		{
			transaction.SetTransition((int)FragmentTransit.None);
		}
	}
}

