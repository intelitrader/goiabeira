using mobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace mobileApp.Views
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