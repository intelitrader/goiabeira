using mobile_app.API;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroPage : ContentPage
    {
        public CadastroPage()
        {
            InitializeComponent();
        }
        private void btnCadastro_Clicked(object sender, EventArgs e)
        {
            var result = APIService.CadastrarUsuario(txtName.Text, txtAge.Text, txtSurname.Text).Result;
            if (result == "error")
            {
                Navigation.PushAsync(new ErrorPage());
            }
            else 
            { 
                Navigation.PushAsync(new EnviadoPage());
            }
        }
    }
}