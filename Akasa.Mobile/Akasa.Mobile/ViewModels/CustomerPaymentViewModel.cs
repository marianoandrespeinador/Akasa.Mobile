using Akasa.Mobile.Models;

namespace Akasa.Mobile.ViewModels
{
	public class CustomerPaymentViewModel : BaseViewModel<Customer>
	{
		public Customer _customer { get; set; }
		public CustomerPaymentViewModel(Customer item = null)
		{
			Title = item.Name;
            _customer = item;
		}

	    private int _quantity = 1;
		public int Quantity
		{
			get => _quantity;
		    set => SetProperty(ref _quantity, value);
		}
	}
}