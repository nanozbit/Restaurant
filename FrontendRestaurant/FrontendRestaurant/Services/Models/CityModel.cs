using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendRestaurant.Services.Models
{
    public class CityModel
    {
        public int IdCiudad { get; set; }
        [Required(ErrorMessage ="Ingrse un nombre de ciudad")]
        public string NombreCiudad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Empty { get { return  string.IsNullOrWhiteSpace(NombreCiudad); } }
    }
}
