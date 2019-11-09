namespace FindMyPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Monedas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moneda",
                c => new
                    {
                        MonedaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MonedaId);
            
            AddColumn("dbo.Inmueble", "MonedaId", c => c.Int());
            CreateIndex("dbo.Inmueble", "MonedaId");
            AddForeignKey("dbo.Inmueble", "MonedaId", "dbo.Moneda", "MonedaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inmueble", "MonedaId", "dbo.Moneda");
            DropIndex("dbo.Inmueble", new[] { "MonedaId" });
            DropColumn("dbo.Inmueble", "MonedaId");
            DropTable("dbo.Moneda");
        }
    }
}
