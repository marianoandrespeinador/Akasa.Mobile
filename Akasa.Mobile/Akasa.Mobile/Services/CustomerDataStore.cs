using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Akasa.Mobile.Models;
using Android.Accounts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(Akasa.Mobile.Services.CustomerDataStore))]
namespace Akasa.Mobile.Services
{
	public class CustomerDataStore : BaseDataStore<Customer>
	{
	    protected override string _basePath
	    {
	        get => "http://192.168.1.9/AkasaAPI/api/User";
	    }
	}
}
