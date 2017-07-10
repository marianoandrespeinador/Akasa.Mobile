using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Akasa.Mobile.Models
{
    public class Customer : BaseDto
	{
	    private string _name = string.Empty;
		public string Name
		{
			get => _name;
		    set => SetProperty(ref _name, value);
        }

        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _phone = string.Empty;
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        private string _emergencyPhone = string.Empty;
        public string EmergencyPhone
        {
            get => _emergencyPhone;
            set => SetProperty(ref _emergencyPhone, value);
        }
    }
}
