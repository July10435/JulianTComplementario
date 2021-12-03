using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.IO;

namespace TapiaExamen
{
    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection con;
        public MainPage()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBsea>().GetConnection();
        }

        public static IEnumerable<RegistroUsuario> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<RegistroUsuario>("SELECT * FROM RegistroUsuario where Usuario = ? and Contrasenia = ?", usuario, contrasenia);
        }
        private async void btn_ingresar_Clicked(object sender, EventArgs e)
        {
            try {
                var documetPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "ComplementarioT.db3");
                var db = new SQLiteConnection(documetPath);
                db.CreateTable<RegistroUsuario>();
                IEnumerable<RegistroUsuario> resultado = SELECT_WHERE(db, txt_usuario.Text, txt_contrasena.Text);
                string usuarioC = txt_usuario.Text;
                if (resultado.Count() > 0)
                {
                    await Navigation.PushAsync(new Registro(usuarioC));
                }
                else
                {
                    await DisplayAlert("Alerta", "No existe ese usuario", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "OK");
            }
        }

        private async void btn_registro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());
        }
    }
}
