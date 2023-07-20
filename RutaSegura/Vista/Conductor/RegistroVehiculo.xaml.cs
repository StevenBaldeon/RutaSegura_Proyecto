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
        
        public RegistroVehiculo ()
		{
			InitializeComponent ();
		}

        private void btnRegistrarVehiculo_Clicked(object sender, EventArgs e)
        {
            
            
            string tipo= pTipoVehiculo.SelectedItem.ToString();


            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("marca", txtMarca.Text);
                parametros.Add("modelo", txtModelo.Text);
                parametros.Add("color", txtColor.Text);
                parametros.Add("placa", txtPlaca.Text);
                parametros.Add("tipoVehiculo", tipo.ToString() );
                cliente.UploadValues("http://10.211.55.6/proyectorutasegura/postVehiculo.php", "POST", parametros);
                Navigation.PushAsync(new PestanaConductor());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }



        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PestanaConductor());
        }
    }
}