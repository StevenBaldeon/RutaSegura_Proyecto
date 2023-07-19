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
        
        public RegistroVehiculo ()
		{
			InitializeComponent ();
		}

        private void pTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrarVehiculo_Clicked(object sender, EventArgs e)
        {
            ////if (string.IsNullOrWhiteSpace(txtMarca.Text) || string.IsNullOrWhiteSpace(txtModelo.Text) ||
            ////   string.IsNullOrWhiteSpace(txtColor.Text) || string.IsNullOrWhiteSpace(txtPlaca.Text))
            ////{
            ////    DisplayAlert("Error", "Todos los campos son obligatorios", "Cerrar");
            ////}
            ////else
            ////{
            ////    DisplayAlert("Registro de Vehiculo", "Vehiculo registrado correctamente", "Cerrar");
            ////}

            //try
            //{
            //    string TipoVehiculo = pTipoVehiculo.SelectedItem as string;

            //    WebClient cliente = new WebClient();
            //    var parametros = new System.Collections.Specialized.NameValueCollection();
            //    parametros.Add("marca", txtMarca.Text);
            //    parametros.Add("modelo", txtModelo.Text);
            //    parametros.Add("color", txtColor.Text);
            //    parametros.Add("placa", txtPlaca.Text);
            //    parametros.Add("tipoVehiculo", );
            //    cliente.UploadValues("http://192.168.56.1/proyectorutasegura/post_vehiculos.php", "POST", parametros);
            //    Navigation.PushAsync(new PestanaConductor());

            //    var mensaje = "Elemento ingresado con exito";
            //    DependencyService.Get<Mensaje>().longAlert(mensaje);
            //}
            //catch (Exception ex)
            //{

            //    DisplayAlert("Alerta", ex.Message, "Cerrar");
            //}
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Perfil(string usuario));
        }
    }
}