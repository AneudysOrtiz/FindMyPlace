using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindMyPlace.Models
{
    public class Inmueble
    {
        [Key]
        public int InmuebleId { get; set; }
        public decimal Precio { get; set; }
        public int TipoVentaId { get; set; }
        public virtual TipoVenta TipoVenta { get; set; }
        public int CondicionId { get; set; }
        public virtual Condicion Condicion { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<AmenidadInmueble> AmenidadInmuebles { get; set; }

    }
}