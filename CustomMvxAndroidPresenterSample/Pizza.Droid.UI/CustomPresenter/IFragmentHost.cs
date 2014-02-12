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
using Cirrious.MvvmCross.ViewModels;
using Pizza.Core;

namespace Pizza.Droid.UI
{
	public interface IFragmentHost
	{
		/// <summary>
		/// Show the specified view model request.
		/// </summary>
		/// <param name="request">Request.</param>
		void Show(MvxViewModelRequest request);

		/// <summary>
		/// Gets fired when a fragment is resumed on this host
		/// </summary>
		/// <param name="viewModel">View model.</param>
		void OnFragmentResumed (IMvxViewModel viewModel);

		/// <summary>
		/// Gets the supported view models with the corresponding region layout
		/// </summary>
		/// <value>The supported view models.</value>
		PresenterRegistrationList SupportedPresenterRegistrations { get; }

		/// <summary>
		/// Gets the current fragment manager.
		/// </summary>
		/// <value>The fragment manager.</value>
		Android.Support.V4.App.FragmentManager CurrentFragmentManager { get; }

		/// <summary>
		/// Raises when the transaction gets created.
		/// </summary>
		/// <param name="transaction">Transaction.</param>
		void OnTransactionCreated (MvxViewModelRequest request, Android.Support.V4.App.FragmentTransaction transaction);
	}
}

