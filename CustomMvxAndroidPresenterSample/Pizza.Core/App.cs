using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using System.Threading;
using System.Globalization;

namespace Pizza.Core {
	public class App : MvxApplication {
		public App() {
			CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
			this.RegisterAppStart<HostViewModel>();
		}

	}
}