using Goiabeira_Xamarin_Mobile.Models;
using Goiabeira_Xamarin_Mobile.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Goiabeira_Xamarin_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaUsuarios : ContentPage
    {
        public ListaUsuarios()
        {
            InitializeComponent();
            Get();
            tabela_usuarios.SelectedItem = null;
        }
        private async void Get()
        {
            ServiceRepository service = new ServiceRepository();
            tabela_usuarios.ItemsSource = await service.Listar();
        }
    }
}