using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Restaurants.Domain.Entities
{
    public class EntityCity
    {
        [Key]
        public int IdCiudad { get; set; }
        [Required]
        public string NombreCiudad { get; set; }

       
        public DateTime FechaCreacion { get; set; }


    }
}
