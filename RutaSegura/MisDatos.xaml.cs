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
    public partial class MisDatos : ContentPage
    {
        
        public MisDatos()
        {
            InitializeComponent();
        }

        public MisDatos(Usuario usuario) : this()
        {
            // Mostrar los datos del usuario en los controles de la interfaz de usuario
            lblNombre.Text = usuario.nombre;
            lblApellido.Text = usuario.apellido;
            lblCelular.Text = usuario.telefono;
        }

        private void btnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}