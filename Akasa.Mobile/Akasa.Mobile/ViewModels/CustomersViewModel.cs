using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Akasa.Mobile.Helpers;
using Akasa.Mobile.Models;
using Akasa.Mobile.Views;

using Xamarin.Forms;

namespace Akasa.Mobile.ViewModels
{
	public class CustomersViewModel : BaseViewModel<Customer>
	{
	    public static string addCustomer = "AddCustomer";
		public ObservableRangeCollection<Customer> Customers { get; set; }
		public Command LoadItemsCommand { get; set; }

		public CustomersViewModel()
		{
			Title = "Browse";
		    Customers = new ObservableRangeCollection<Customer>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			MessagingCenter.Subscribe<NewCustomerPage, Customer>(this, addCustomer, async (obj, item) =>
			{
				var _item = item;
			    Customers.Add(_item);
				await DataStore.AddItemAsync(_item);
			});
		}

	    private async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
			    Customers.Clear();
				var items = await DataStore.GetItemsAsync(true);
			    Customers.ReplaceRange(items);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				MessagingCenter.Send(new MessagingCenterAlert
				{
					Title = "Error",
					Message = "Unable to load customers.",
					Cancel = "OK"
				}, "message");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}