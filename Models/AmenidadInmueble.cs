using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindMyPlace.Models
{
    public class AmenidadInmueble
    {
        [Key]
        public int AmenidadInmuebleId { get; set; }
        public int AmenidadId { get; set; }
        public virtual Amenidad Amenidad { get; set; }
        public int InmuebleId { get; set; }
        public virtual Inmueble Inmueble { get; set; }
    }
}