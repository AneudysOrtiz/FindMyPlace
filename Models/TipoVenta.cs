using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindMyPlace.Models
{
    public class TipoVenta
    {
        [Key]
        public int TipoVentaId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Inmueble> Inmuebles { get; set; }
    }
}