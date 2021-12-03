using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TapiaExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        String nombre = null;
        double pagoIni = 0;
        double pagofinal = 0;
        string _usuario;

        public Registro(string usuarioC)
        {

            InitializeComponent();
            _usuario = usuarioC;
        }

        private void btn_calcular_Clicked(object sender, EventArgs e)
        {

            pagoIni = Convert.ToDouble(txt_montoini.Text);


            Double cuotas;
            Double interes = 0;

            if (pagoIni < 1800)
            {
                cuotas = (1800 - pagoIni) / 3;
                interes = (1800 * 0.05) + cuotas;         
                txt_pagomen.Text = Convert.ToString(interes);
                pagofinal = interes * 3;
                txt_pagoT.Text = Convert.ToString(pagofinal);
            }

        }

        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txt_codigo.Text);
                parametros.Add("nombre", txt_name.Text);
                parametros.Add("pagoI", txt_montoini.Text);
                parametros.Add("pagoM", txt_pagomen.Text);
                parametros.Add("pagoT", txt_pagoT.Text);
                cliente.UploadValues("http://192.168.0.108/moviles/post.php", "POST", parametros);
                nombre = txt_name.Text;
                await DisplayAlert("alerta", "ingreso correcto", "ok");
                await Navigation.PushAsync(new Resumen(_usuario, pagofinal, nombre));
            }
            catch (Exception ex)
            {
                await DisplayAlert ("alerta", ex.Message, "OK");
            }
        }
    }
}