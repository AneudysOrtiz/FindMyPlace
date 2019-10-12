using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindMyPlace.Models
{
    public class Condicion
    {
        [Key]
        public int CondicionId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Inmueble> Inmuebles { get; set; }

    }
}