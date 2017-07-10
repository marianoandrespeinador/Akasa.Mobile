using System;
using System.Windows.Input;
using Akasa.Mobile.Models;
using Xamarin.Forms;

namespace Akasa.Mobile.ViewModels
{
	public class AboutViewModel : BaseViewModel<Customer>
	{
		public AboutViewModel()
		{
			Title = "About";

			OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
		}

		/// <summary>
		/// Command to open browser to xamarin.com
		/// </summary>
		public ICommand OpenWebCommand { get; }
	}
}
