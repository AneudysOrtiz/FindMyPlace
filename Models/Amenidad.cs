using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindMyPlace.Models
{
    public class Amenidad
    {
        [Key]
        public int AmenidadId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<AmenidadInmueble> AmenidadInmuebles { get; set; }
    }
}