namespace FindMyPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amenidad",
                c => new
                    {
                        AmenidadId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.AmenidadId);
            
            CreateTable(
                "dbo.AmenidadInmueble",
                c => new
                    {
                        AmenidadInmuebleId = c.Int(nullable: false, identity: true),
                        AmenidadId = c.Int(nullable: false),
                        InmuebleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AmenidadInmuebleId)
                .ForeignKey("dbo.Amenidad", t => t.AmenidadId, cascadeDelete: true)
                .ForeignKey("dbo.Inmueble", t => t.InmuebleId, cascadeDelete: true)
                .Index(t => t.AmenidadId)
                .Index(t => t.InmuebleId);
            
            CreateTable(
                "dbo.Inmueble",
                c => new
                    {
                        InmuebleId = c.Int(nullable: false, identity: true),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoVentaId = c.Int(nullable: false),
                        CondicionId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InmuebleId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Condicion", t => t.CondicionId, cascadeDelete: true)
                .ForeignKey("dbo.TipoVenta", t => t.TipoVentaId, cascadeDelete: true)
                .Index(t => t.TipoVentaId)
                .Index(t => t.CondicionId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Condicion",
                c => new
                    {
                        CondicionId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.CondicionId);
            
            CreateTable(
                "dbo.TipoVenta",
                c => new
                    {
                        TipoVentaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoVentaId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Inmueble", "TipoVentaId", "dbo.TipoVenta");
            DropForeignKey("dbo.Inmueble", "CondicionId", "dbo.Condicion");
            DropForeignKey("dbo.Inmueble", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.AmenidadInmueble", "InmuebleId", "dbo.Inmueble");
            DropForeignKey("dbo.AmenidadInmueble", "AmenidadId", "dbo.Amenidad");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Inmueble", new[] { "CategoriaId" });
            DropIndex("dbo.Inmueble", new[] { "CondicionId" });
            DropIndex("dbo.Inmueble", new[] { "TipoVentaId" });
            DropIndex("dbo.AmenidadInmueble", new[] { "InmuebleId" });
            DropIndex("dbo.AmenidadInmueble", new[] { "AmenidadId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TipoVenta");
            DropTable("dbo.Condicion");
            DropTable("dbo.Categoria");
            DropTable("dbo.Inmueble");
            DropTable("dbo.AmenidadInmueble");
            DropTable("dbo.Amenidad");
        }
    }
}
