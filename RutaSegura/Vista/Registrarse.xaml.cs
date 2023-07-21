using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RutaSegura.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrarse : ContentPage
    {
        public Registrarse()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            try
            {
                string perfil = pkPerfil.SelectedItem as string;
                string fechaNac = Convert.ToString(dpFechaNacimiento);

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("telefono", txtTelefono.Text);
                parametros.Add("email", txtCorreo.Text);
                parametros.Add("contrasena", txtContraseña.Text);                
                parametros.Add("fechaNacimiento", fechaNac );
                parametros.Add("perfil", perfil);
                cliente.UploadValues("http://192.168.56.1/ProyectoRutaSegura/post_usuarios.php", "POST", parametros);
                Navigation.PushAsync(new Login());

                var mensaje = "Elemento ingresado con éxito";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}