using GrowUpSystemUI.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace GrowUpSystemUI.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}