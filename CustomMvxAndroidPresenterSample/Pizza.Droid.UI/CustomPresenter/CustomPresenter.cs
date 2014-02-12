using System;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Exceptions;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Views;
using Cirrious.CrossCore.Droid.Platform;
using System.Collections.Generic;
using Android.App;

namespace Pizza.Droid.UI
{

	public interface ICustomPresenter
	{
		void RegisterHost(IFragmentHost host);
	}

	public class CustomPresenter : MvxAndroidViewPresenter, ICustomPresenter
	{
		private Dictionary<Type, IFragmentHost> _registeredHosts = new Dictionary<Type, IFragmentHost>();

		public override void Show(MvxViewModelRequest request)
		{
			//Show view
			IFragmentHost host;
			if (ResolveHost (request.ViewModelType, out host)) {
				host.Show(request);
			} else {
				base.Show(request);
			}
		}

		private bool ResolveHost(Type typeOfViewModel, out IFragmentHost host)
		{
			foreach(var hst in _registeredHosts)
			{
				if (hst.Value.SupportedPresenterRegistrations.ContainsViewModel(typeOfViewModel))
				{
					host = hst.Value;
					return true;
				}
			}

			host = null;
			return false;
		}

		/// <summary>
		/// Registers the host that is provided.
		/// </summary>
		/// <param name="host">Host.</param>
		public void RegisterHost (IFragmentHost host)
		{
			//Make sure each host can only be registered once. Otherwise it will be overwritten.
			_registeredHosts [host.GetType ()] = host;
		}

		public override void ChangePresentation (MvxPresentationHint hint)
		{
			base.ChangePresentation (hint);
		}

	}
}