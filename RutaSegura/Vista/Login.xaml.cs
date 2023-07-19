using RutaSegura.Vista;
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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            string usuario = "uisrael";
            string contrasena = "1234";

                if (txtUsuario.Text == usuario && txtContrasena.Text == contrasena)
            {
                Navigation.PushAsync(new PestanaConductor());
            }
            else
            {
                DisplayAlert("Alerta", "Usuario/Contrasena invalido", "Cerrar");
            }
        }

        private void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registrarse());
        }
    }
}