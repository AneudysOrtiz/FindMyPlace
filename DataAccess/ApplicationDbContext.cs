using FindMyPlace.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FindMyPlace.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Amenidad> Amenidades { get; set; }
        public DbSet<AmenidadInmueble> AmenidadesInmuebles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Condicion> Condiciones { get; set; }
        public DbSet<Inmueble> Inmuebles { get; set; }
        public DbSet<TipoVenta> TipoVentas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}