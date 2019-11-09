namespace FindMyPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inmuebles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inmueble", "Direccion", c => c.String(nullable: false));
            AddColumn("dbo.Inmueble", "Habitaciones", c => c.Int(nullable: false));
            AddColumn("dbo.Inmueble", "Area", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Amenidad", "Descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.Categoria", "Nombre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categoria", "Nombre", c => c.String());
            AlterColumn("dbo.Amenidad", "Descripcion", c => c.String());
            DropColumn("dbo.Inmueble", "Area");
            DropColumn("dbo.Inmueble", "Habitaciones");
            DropColumn("dbo.Inmueble", "Direccion");
        }
    }
}
