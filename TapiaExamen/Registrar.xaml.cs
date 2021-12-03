using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TapiaExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registrar()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBsea>().GetConnection();
        }

        private void btn_registrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Registros = new RegistroUsuario { Usuario = txt_usuarioN.Text, Contrasenia = txt_contrasenaN.Text };
                con.InsertAsync(Registros);
                DisplayAlert("Alerta", "Dato ingresado", "OK");
                txt_usuarioN.Text = "";
                txt_contrasenaN.Text = "";
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }
    }
}