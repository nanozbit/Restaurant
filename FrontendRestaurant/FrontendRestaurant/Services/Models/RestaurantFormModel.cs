using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendRestaurant.Services.Models
{
    public class RestaurantFormModel
    {
        public int IdRestaurante   { get; set; }
        [Required(ErrorMessage = "Ingrese un mombre para el restaurante")]
        public string NombreRestaurante { get; set; }
        public string NombreCiudad { get; set; }
        public List<CityModel> Ciudad { get; set; }
        [Required (ErrorMessage = "Ingrese la cantidad del aforo")]
        public int NumeroAforo { get; set; }
        [Required (ErrorMessage = "Ingrese un numero Telefono")]
        [MinLength(9, ErrorMessage = "Ingrese un numero de telefono valido")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Seleccione una ciudad")]
        public int IdCiudad { get; set; }
    }
}
