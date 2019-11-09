namespace FindMyPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Decripcioninmueble : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inmueble", "Codigo", c => c.String());
            AddColumn("dbo.Inmueble", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inmueble", "Descripcion");
            DropColumn("dbo.Inmueble", "Codigo");
        }
    }
}
