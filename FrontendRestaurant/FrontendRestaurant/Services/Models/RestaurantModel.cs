using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendRestaurant.Services.Models
{
    public class RestaurantModel
    {
        public int IdRestaurante { get; set; }
        [Required]
        public string NombreRestaurante { get; set; }
        public string NombreCiudad { get; set; }
        public List<CityModel> Ciudad { get; set; }
        [Required]
        public int NumeroAforo { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Ingrese un numero de telefono valido")]
        public string Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdCiudad { get; set; }
    }
}
