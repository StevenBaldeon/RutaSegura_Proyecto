using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RutaSegura.Vista.Conductor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RutasConductor : ContentPage
    {
        public RutasConductor()
        {
            InitializeComponent();
        }

        private void btnIngresarRuta_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("InicioRuta", txtInicioRuta.Text);
                parametros.Add("sector", txtSector.Text);
                parametros.Add("barrio", txtBarrio.Text);
                parametros.Add("callePrincipal", txtCalleP.Text);
                parametros.Add("calle_Secundaria", txtCalleS.Text);
                parametros.Add("referencia", txtReferencia.Text);
                cliente.UploadValues("http://192.168.100.36/ProyectoRutaSegura/post_ruta.php", "POST", parametros);
                Navigation.PushAsync(new PestanaConductor());

                var mensaje = "Ruta ingresada con éxito";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}