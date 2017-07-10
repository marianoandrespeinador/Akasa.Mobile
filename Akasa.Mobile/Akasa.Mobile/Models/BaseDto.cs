using System;
using Akasa.Mobile.Helpers;

namespace Akasa.Mobile.Models
{
    public class BaseDto : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
    }
}
