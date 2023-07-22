using System;
using System.Collections.Generic;
using System.Text;

namespace RutaSegura
{
    public class Usuario
    {
        public int idUsuarios { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string perfil { get; set; }
        public int idVehiculo { get; set; }
    }
}
