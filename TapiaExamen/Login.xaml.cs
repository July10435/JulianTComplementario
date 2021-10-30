using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TapiaExamen
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btn_ingresar_Clicked(object sender, EventArgs e)
        {
            String usuario = Convert.ToString(txt_usuario.Text);
            String contrasena = Convert.ToString(txt_contrasena.Text);

            if (usuario == "estudiante2021" && contrasena == "uisrael2021")
            {
                await Navigation.PushAsync(new Registro());
            }
            else
                await DisplayAlert("Ingreso", "Fallido", "OK");
        }
    }
}
