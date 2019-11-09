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
        public string Codigo { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Display(Name ="Tipo de Venta")]
        [Required]
        public int TipoVentaId { get; set; }
        [Required]
        public string Direccion { get; set; }
        public virtual TipoVenta TipoVenta { get; set; }
        [Display(Name = "Condición")]
        [Required]
        public int CondicionId { get; set; }
        public virtual Condicion Condicion { get; set; }
        [Display(Name = "Categoría")]
        [Required]
        public int CategoriaId { get; set; }
        public int Habitaciones { get; set; }
        public int? MonedaId { get; set; }
        public decimal Area { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Moneda Moneda { get; set; }
        public virtual ICollection<AmenidadInmueble> AmenidadInmuebles { get; set; }

    }
}