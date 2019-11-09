namespace FindMyPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inmueble", "Latitude", c => c.String());
            AddColumn("dbo.Inmueble", "Longitude", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inmueble", "Longitude");
            DropColumn("dbo.Inmueble", "Latitude");
        }
    }
}
