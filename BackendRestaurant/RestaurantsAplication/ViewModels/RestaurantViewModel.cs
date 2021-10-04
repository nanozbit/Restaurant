using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantsAplication.ViewModels
{
    public class RestaurantViewModel
    {
        public int IdRestaurante { get; set; }
        public string NombreRestaurante { get; set; }
        public int NumeroAforo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdCiudad { get; set; }
    }
}
