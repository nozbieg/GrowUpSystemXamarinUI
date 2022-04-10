using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace GrowUpSystemUI.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Log In";
            OpenWebCommand = new Command(async () => await Shell.Current.GoToAsync("//LoginPage"));
        }

        public ICommand OpenWebCommand { get; }
    }
}