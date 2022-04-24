using System;
using System.Linq;
using GrowUpSystemUI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowUpSystemUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HumidityPage : ContentPage
    {
        public HumidityPage()
        {
            InitializeComponent();
            var viewModel = new HumidityViewModel();
            BindingContext = viewModel;
        }
    }
}