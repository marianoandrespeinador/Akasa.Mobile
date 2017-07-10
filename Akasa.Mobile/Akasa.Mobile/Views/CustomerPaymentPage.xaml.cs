
using Akasa.Mobile.ViewModels;

using Xamarin.Forms;

namespace Akasa.Mobile.Views
{
	public partial class CustomerPaymentPage : ContentPage
	{
	    private CustomerPaymentViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public CustomerPaymentPage()
        {
            InitializeComponent();
        }

        public CustomerPaymentPage(CustomerPaymentViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}
	}
}
