using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindMyPlace.Models
{
    public class Moneda
    {
        [Key]
        public int MonedaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public virtual ICollection<Inmueble> Inmuebles { get; set; }
    }
}