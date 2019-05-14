using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace InfoplusTest2.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://sites.google.com/site/oleksandrziborov/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}