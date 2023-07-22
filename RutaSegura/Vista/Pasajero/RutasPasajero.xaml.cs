using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RutaSegura
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RutasPasajero : ContentPage
    {
        private string Url = "http://192.168.100.108/proyectorutasegura/post_ruta.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<RutasP> post;
        public RutasPasajero()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var contenido = await cliente.GetStringAsync(Url);
            List<RutasP> listaPost = JsonConvert.DeserializeObject<List<RutasP>>(contenido);
            post = new ObservableCollection<RutasP>(listaPost);
            listaVehiculos.ItemsSource = post;
        }
    }
}