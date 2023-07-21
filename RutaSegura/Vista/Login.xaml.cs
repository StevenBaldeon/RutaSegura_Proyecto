﻿using RutaSegura.Vista;
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

        private  void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            
           
            /*Login1 log = new Login1
            {
                correo = txtUsuario.Text,
                contrasena = txtContrasena.Text
            };

            Uri RequestUri = new Uri("http://localhost:8080/login");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson =new StringContent(json, Encoding.UTF8,"aplication/json");
            var response = await client.PostAsync(RequestUri, contentJson);
            
            if (response.StatusCode ==HttpStatusCode.OK)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<Login1>(responseContent);

                // Suponiendo que el objeto "usuario" contiene una propiedad "perfil" que indica el perfil del usuario
                if (usuario.perfil == "conductor")
                {
                    await Navigation.PushAsync(new PestanaConductor());
                }
                else if (usuario.perfil == "pasajero")
                {
                    await Navigation.PushAsync(new PestanaPasajero());
                }
                else
                {
                    await DisplayAlert("Alerta", "Perfil de usuario desconocido", "Cerrar");
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Usuario/Contraseña inválido", "Cerrar");
            }*/
            

                string usuarioc= "conductor";
                string contrasenac = "1234";
                string usuariop = "pasajero";
                string contrasenap = "1234";

            if (txtUsuario.Text == usuarioc && txtContrasena.Text == contrasenac)
            {
                Navigation.PushAsync(new MisDatos());
                Navigation.PushAsync(new PestanaConductor());
            }
            if(txtUsuario.Text == usuariop && txtContrasena.Text == contrasenap)
            {
                Navigation.PushAsync(new PestanaPasajero());
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