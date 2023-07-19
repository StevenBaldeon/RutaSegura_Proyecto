using System;
using System.Collections.Generic;
using System.Text;

namespace RutaSegura
{
    public interface Mensaje
    {
        void shortAlert(string mensaje);
        void longAlert(string mensaje);
    }
}
