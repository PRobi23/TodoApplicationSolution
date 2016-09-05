using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight;

namespace TodoApplication.ViewModel
{
    class TodoItemViewModel : ViewModelBase
    {
        private readonly string _expirationTimestamp;

        public TodoItemViewModel(string name)
        {
            _expirationTimestamp = name;
        }

        string _remainingTimeString;
        public string RemainingTimeString
        {
            get
            {
                return _remainingTimeString;
            }
            set
            {
                if (value == _remainingTimeString) return;
                _remainingTimeString = value;
                RaisePropertyChanged(nameof(RemainingTimeString));
            }
        }


    }
}
