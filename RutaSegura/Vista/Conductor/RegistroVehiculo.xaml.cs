using RutaSegura.Vista.Conductor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RutaSegura
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroVehiculo : ContentPage
    {

        public RegistroVehiculo()
        {
            InitializeComponent();
        }

        private void btnRegistrarVehiculo_Clicked(object sender, EventArgs e)
        {


            string tipo = pTipoVehiculo.SelectedItem.ToString();

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("marca", txtMarca.Text);
            parametros.Add("modelo", txtModelo.Text);
            parametros.Add("color", txtColor.Text);
            parametros.Add("placa", txtPlaca.Text);
            parametros.Add("tipovehiculo", tipo.ToString());
            cliente.UploadValues("http://192.168.100.108/proyectorutasegura/post_vehiculos.php", "POST", parametros);

            Navigation.PushAsync(new PestanaConductor());

            var mensaje = "Elemento ingresado con exito";
            DependencyService.Get<Mensaje>().longAlert(mensaje);



        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PestanaConductor());
        }
    }
}