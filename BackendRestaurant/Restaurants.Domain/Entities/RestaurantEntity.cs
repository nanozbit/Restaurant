using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Restaurants.Domain.Entities
{
    public class RestaurantEntity
    {
        [Key]
        public int IdRestaurante { get; set; }
        public string NombreRestaurante { get; set; }
        public int  NumeroAforo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }
        [ForeignKey("IdCiudad")]
        public EntityCity Ciudad { get; set; }
        public  int  IdCiudad { get; set; }
    }
}
