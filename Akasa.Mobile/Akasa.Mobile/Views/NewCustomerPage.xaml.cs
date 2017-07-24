using System;

using Akasa.Mobile.Models;
using Akasa.Mobile.ViewModels;
using Xamarin.Forms;

namespace Akasa.Mobile.Views
{
	public partial class NewCustomerPage : ContentPage
	{
		public Customer Customer { get; set; }

		public NewCustomerPage()
		{
			InitializeComponent();

		    Customer = new Customer();

			BindingContext = this;
		}

	    private async void Save_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, CustomersViewModel.addCustomer, Customer);
			await Navigation.PopToRootAsync();
		}
	}
}