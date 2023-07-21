using RutaSegura.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net.Http;
using System.Net;

namespace RutaSegura
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        public void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            /* 
            string correo = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("correo", correo);
            parametros.Add("contrasena", contrasena);

            try
            {
                // Hacer una solicitud POST al archivo PHP para validar el inicio de sesión
                byte[] respuesta = cliente.UploadValues("http://10.2.8.66/ProyectoRutaSegura/post_login2.php", "POST", parametros);
                string resultado = Encoding.UTF8.GetString(respuesta);

                // Analizar la respuesta para validar el inicio de sesión
                if (resultado == "OK")
                {
                    // Inicio de sesión exitoso: redirigir a la página principal
                    // Por ejemplo, puedes usar Navigation para navegar a otra página
                    Navigation.PushAsync(new PestanaConductor());
                }
                else
                {
                    // Credenciales incorrectas: mostrar un mensaje de error
                    DisplayAlert("Error", "Credenciales incorrectas. Inténtalo nuevamente.", "Aceptar");
                }
            }
            catch (WebException ex)
            {
                // Capturar y manejar errores de conexión o solicitud HTTP aquí
                DisplayAlert("Error", "No se pudo conectar al servidor. Verifica tu conexión a internet.", "Aceptar");
            }

            */

            string correo = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("correo", correo);
            parametros.Add("contrasena", contrasena);

            try
            {
                // Hacer una solicitud POST al archivo PHP para validar el inicio de sesión
                byte[] respuesta = cliente.UploadValues("http://10.2.8.66/ProyectoRutaSegura/post_login2.php", "POST", parametros);
                string resultado = Encoding.UTF8.GetString(respuesta);

                // Analizar la respuesta para validar el inicio de sesión
                if (resultado == "OK")
                {
                    // Inicio de sesión exitoso: obtener el perfil del usuario desde la base de datos
                    WebClient perfilCliente = new WebClient();
                    byte[] perfilRespuesta = perfilCliente.UploadValues("http://10.2.8.66/ProyectoRutaSegura/post_ObtenerPerfil.php", "POST", parametros);
                    string perfilResultado = Encoding.UTF8.GetString(perfilRespuesta);

                    if (perfilResultado == "Conductor")
                    {
                        // Redirigir a la página del conductor (PestanaConductor)
                        Navigation.PushAsync(new PestanaConductor());
                    }
                    else if (perfilResultado == "Pasajero")
                    {
                        // Redirigir a la página del pasajero (PestanaPasajero)
                        Navigation.PushAsync(new PestanaPasajero());
                    }
                    else
                    {
                        // El perfil no es válido: mostrar un mensaje de error
                        DisplayAlert("Error", "Perfil no válido. Contacta al administrador.", "Aceptar");
                    }
                }
                else
                {
                    // Credenciales incorrectas: mostrar un mensaje de error
                    DisplayAlert("Error", "Credenciales incorrectas. Inténtalo nuevamente.", "Aceptar");
                }
            }
            catch (WebException ex)
            {
                // Capturar y manejar errores de conexión o solicitud HTTP aquí
                DisplayAlert("Error", "No se pudo conectar al servidor. Verifica tu conexión a internet.", "Aceptar");
            }

        }

        private void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registrarse());
        }
    }
}