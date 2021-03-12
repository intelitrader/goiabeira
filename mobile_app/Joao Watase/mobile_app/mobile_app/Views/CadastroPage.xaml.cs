using mobile_app.API;
using System;
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
        public async void Cadastrar(string name, string age, string surname = null)
        {
            await APIService.CadastrarUsuario(name, age, surname);
        }
        private void btnCadastro_Clicked(object sender, EventArgs e)
        {
            Cadastrar(txtName.Text, txtAge.Text, txtSurname.Text);
            Navigation.PushAsync(new EnviadoPage());
        }
    }
}