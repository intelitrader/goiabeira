using AppMobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }


        private async void BtnCallWS_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(firstNameInput.Text) && !String.IsNullOrWhiteSpace(surNameInput.Text) && !String.IsNullOrWhiteSpace(ageInput.Text))
            {
                HttpConnection function = new HttpConnection();

                //transformar o age em int 
                await function.AddEntidade(firstNameInput.Text, surNameInput.Text, Convert.ToInt32(ageInput.Text));

                firstNameInput.Text = surNameInput.Text = ageInput.Text = string.Empty;

                await DisplayAlert("Cadastrado", "Usuário cadastrado com sucesso!", "Ok");
            }
            else
            {
                await DisplayAlert("Erro", "Preencha todos os espaços e tente novamente!", "Ok");
            }

        }
    }
}