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
    public partial class Resumen : ContentPage
    {
        double _pagoFinal;
        string _nombre;
        string _usuarioC;
        public Resumen(string usuarioC, double pagofinal, string nombre)
        {
            InitializeComponent();
            _usuarioC = usuarioC;
            _nombre = nombre;
            _pagoFinal = pagofinal;
            txt_user.Text = _usuarioC;
            txt_name.Text = _nombre;
            txt_pagoTotal.Text = Convert.ToString(_pagoFinal);
        }
    }
}