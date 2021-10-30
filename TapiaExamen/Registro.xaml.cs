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
    public partial class Registro : ContentPage
    {
        String nombre = null;
        Double pagoIni = 0;
        Double pagofinal = 0;

        public Registro()
        {

            InitializeComponent();
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
            }

        }

        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            nombre = Convert.ToString(txt_name.Text);
            await DisplayAlert("Ingreso", "Elemento guardado con exito", "OK");


            await Navigation.PushAsync(new Resumen(pagofinal, nombre));
        }
    }
}