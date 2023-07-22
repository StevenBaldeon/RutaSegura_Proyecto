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

        public async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            string correo = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("correo", correo);
            parametros.Add("contrasena", contrasena);

            try
            {
                // Hacer una solicitud POST al archivo PHP para validar el inicio de sesión
                byte[] respuesta = cliente.UploadValues("http://192.168.100.108/ProyectoRutaSegura/post_login2.php", "POST", parametros);
                string resultado = Encoding.UTF8.GetString(respuesta);

                // Analizar la respuesta para validar el inicio de sesión
                if (resultado == "OK")
                {
                    // Inicio de sesión exitoso: obtener el perfil del usuario desde la base de datos
                    WebClient perfilcliente = new WebClient();
                    byte[] perfilrespuesta = perfilcliente.UploadValues("http://192.168.100.108/ProyectoRutaSegura/post_ObtenerPerfil.php", "POST", parametros);
                    string perfilresultado = Encoding.UTF8.GetString(perfilrespuesta);

                    if (perfilresultado == "Conductor")
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            var datosUsuarioUrl = "http://192.168.100.108/ProyectoRutaSegura/post_ObtenerDatos.php";

                            // Crear un objeto JSON que contiene el correo del usuario
                            var datosUsuarioJson = new { correo = correo };

                            var contenido = new StringContent(JsonConvert.SerializeObject(datosUsuarioJson), Encoding.UTF8, "application/json");

                            // Enviar la solicitud POST al servidor
                            var respuestaDatosUsuario = await httpClient.PostAsync(datosUsuarioUrl, contenido);

                            if (respuestaDatosUsuario.IsSuccessStatusCode)
                            {
                                // Leer la respuesta JSON y deserializarla en un objeto Usuario
                                var contenidoRespuesta = await respuestaDatosUsuario.Content.ReadAsStringAsync();
                                var usuario = JsonConvert.DeserializeObject<Usuario>(contenidoRespuesta);

                                // Redirigir a la página MisDatos, enviando los datos del usuario como parámetro
                                await Navigation.PushAsync(new MisDatos(usuario));
                            }
                            else
                            {
                                
                            }
                        }
                        // Redirigir a la página del conductor (PestanaConductor)
                        await Navigation.PushAsync(new PestanaConductor());
                        
                    }
                    else if (perfilresultado == "Pasajero")
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            var datosUsuarioUrl = "http://192.168.100.108/ProyectoRutaSegura/post_ObtenerDatos.php";

                            // Crear un objeto JSON que contiene el correo del usuario
                            var datosUsuarioJson = new { correo = correo };

                            var contenido = new StringContent(JsonConvert.SerializeObject(datosUsuarioJson), Encoding.UTF8, "application/json");

                            // Enviar la solicitud POST al servidor
                            var respuestaDatosUsuario = await httpClient.PostAsync(datosUsuarioUrl, contenido);

                            if (respuestaDatosUsuario.IsSuccessStatusCode)
                            {
                                // Leer la respuesta JSON y deserializarla en un objeto Usuario
                                var contenidoRespuesta = await respuestaDatosUsuario.Content.ReadAsStringAsync();
                                var usuario = JsonConvert.DeserializeObject<Usuario>(contenidoRespuesta);

                                // Redirigir a la página MisDatos, enviando los datos del usuario como parámetro
                                await Navigation.PushAsync(new MisDatos(usuario));
                            }
                            else
                            {

                            }
                        }
                        // Redirigir a la página del pasajero (PestanaPasajero)
                        await Navigation.PushAsync(new PestanaPasajero());
                    }



                    else
                    {
                        // El perfil no es válido: mostrar un mensaje de error
                        await DisplayAlert("Error", "Perfil no válido. Contacta al administrador.", "Aceptar");
                    }



                }
                else
                {
                    // Credenciales incorrectas: mostrar un mensaje de error
                     await DisplayAlert("Error", "Credenciales incorrectas. Inténtalo nuevamente.", "Aceptar");
                }
            }
            catch (WebException ex)
            {
                // Capturar y manejar errores de conexión o solicitud HTTP aquí
                await DisplayAlert("Error", "No se pudo conectar al servidor. Verifica tu conexión a internet.", "Aceptar");
            }



        }

        private void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registrarse());
        }
    }
}