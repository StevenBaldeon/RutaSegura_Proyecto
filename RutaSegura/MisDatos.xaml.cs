using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RutaSegura
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisDatos : ContentPage
    {
        string usuarioglobal;
        public MisDatos(string usuario)
        {
            InitializeComponent();
            lblUsuario.Text = usuario;
            usuarioglobal = usuario;
        }
    }
}