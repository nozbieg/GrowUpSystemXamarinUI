using System;
using System.Linq;
using GrowUpSystemUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowUpSystemUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemperaturePage : ContentPage
    {

        public TemperaturePage()
        {
            InitializeComponent();
            var viewModel = new TemperatureViewModel();
            BindingContext = viewModel;
        }
    }
}