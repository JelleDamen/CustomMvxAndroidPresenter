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
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Views;
using Cirrious.CrossCore.Exceptions;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;

namespace Pizza.Droid.UI
{

	public class FragmentHostHelper
	{
		public static MvxViewModelResponse Show(MvxViewModelRequest request, IFragmentHost host)
		{
			var response = new MvxViewModelResponse();

			//Resolve viewFinder
			var viewFinder = Mvx.Resolve<IMvxViewsContainer>(); 
			var presenter = Mvx.Resolve<ICustomPresenter> ();

			//Resolve viewtype of viewmodel
			var viewType = viewFinder.GetViewType (request.ViewModelType);
			if (viewType == null)
				throw new MvxException ("View Type not found for " + request.ViewModelType);

			//Create instance of view
			var viewObject = Activator.CreateInstance (viewType);
			if (viewObject == null)
				throw new MvxException ("View not loaded for " + viewType);

			var viewModelLoader = Mvx.Resolve<IMvxViewModelLoader> ();
			IMvxFragmentView fragment = viewObject as IMvxFragmentView;


			//We only host fragments
			if (fragment!=null) { // View is a fragment, that should be hosted

				fragment.ViewModel = viewModelLoader.LoadViewModel (request, null);
				Android.Support.V4.App.Fragment frag = viewObject as Android.Support.V4.App.Fragment;

				//Do we know where to put this fragment?
				if(!host.SupportedPresenterRegistrations.ContainsViewModel(request.ViewModelType)) 
					throw new MvxException ("Unable to host fragment " + viewType + ". Because it's host does not support this region.");

				//Resolve regionId
				int regionId = host.SupportedPresenterRegistrations.GetRegionId(request.ViewModelType);

				//Push fragment to the view
				var trans = host.CurrentFragmentManager.BeginTransaction ();
				host.OnTransactionCreated(request,trans);
				trans.Replace (regionId,frag).Commit ();

				response.RegionId = regionId;
				response.Fragment = fragment;

			} else {
				throw new MvxException ("Unable to host view, since this view is not a fragment " + viewType);
			}

			return response;
		}
	}

	public class MvxViewModelResponse {
		public int RegionId {
			get;
			set;
		}

		public IMvxFragmentView Fragment {
			get;
			set;
		}

		public bool IsEmpty {
			get{ 
				return (Fragment == null);
			}
		}
	}
}

