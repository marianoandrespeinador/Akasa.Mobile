
using Akasa.Mobile.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(Akasa.Mobile.Services.CustomerDataStore))]
namespace Akasa.Mobile.Services
{
	public class CustomerDataStore : BaseDataStore<Customer>
	{
	    protected override string _baseBath => "http://192.168.1.5/AkasaAPI/api/User";
	}
}
