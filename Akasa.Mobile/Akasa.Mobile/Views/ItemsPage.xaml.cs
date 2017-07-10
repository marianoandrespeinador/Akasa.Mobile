using System;

using Akasa.Mobile.Models;
using Akasa.Mobile.ViewModels;

using Xamarin.Forms;

namespace Akasa.Mobile.Views
{
	public partial class ItemsPage : ContentPage
	{
	    private ItemsViewModel viewModel;

		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ItemsViewModel();
		}

	    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Customer;
			if (item == null)
				return;

			await Navigation.PushAsync(new CustomerPaymentPage(new CustomerPaymentViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

	    private async void AddCustomer_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewCustomerPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Customers.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}
	}
}
