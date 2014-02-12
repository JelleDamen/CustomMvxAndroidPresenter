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
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using Pizza.Core;

namespace Pizza.Droid.UI
{
	public class MvxHostFragment : MvxFragment, IFragmentHost
	{

		PresenterRegistrationList _presenterRegistrationList;

		public MvxHostFragment (PresenterRegistrationList presenterRegistrationList)
		{
			_presenterRegistrationList = presenterRegistrationList;
		}

		public virtual void OnFragmentResumed (IMvxViewModel viewModel)
		{
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			var presenter = Mvx.Resolve<ICustomPresenter> ();
			presenter.RegisterHost (this);

			base.OnCreate (savedInstanceState);
		}

		/// <summary>
		/// Show the specified view model request.
		/// </summary>
		/// <param name="request">Request.</param>
		public virtual void Show (MvxViewModelRequest request)
		{
			//Execute this request by the FragmentHostHelper
			FragmentHostHelper.Show (request, this);
		}

		/// <summary>
		/// Gets the current fragment manager.
		/// </summary>
		/// <value>The fragment manager.</value>
		public virtual Android.Support.V4.App.FragmentManager CurrentFragmentManager {
			get {
				return this.ChildFragmentManager;
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

