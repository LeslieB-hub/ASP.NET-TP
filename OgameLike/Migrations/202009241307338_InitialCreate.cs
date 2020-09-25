namespace OgameLike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CaseNb = c.Int(),
                        Energy_Id = c.Long(),
                        Oxygen_Id = c.Long(),
                        Steel_Id = c.Long(),
                        Uranium_Id = c.Long(),
                        SolarSystem_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.Energy_Id)
                .ForeignKey("dbo.Resources", t => t.Oxygen_Id)
                .ForeignKey("dbo.Resources", t => t.Steel_Id)
                .ForeignKey("dbo.Resources", t => t.Uranium_Id)
                .ForeignKey("dbo.SolarSystems", t => t.SolarSystem_Id)
                .Index(t => t.Energy_Id)
                .Index(t => t.Oxygen_Id)
                .Index(t => t.Steel_Id)
                .Index(t => t.Uranium_Id)
                .Index(t => t.SolarSystem_Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        LasMyProperty = c.Int(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SolarSystems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Planets", "SolarSystem_Id", "dbo.SolarSystems");
            DropForeignKey("dbo.Planets", "Uranium_Id", "dbo.Resources");
            DropForeignKey("dbo.Planets", "Steel_Id", "dbo.Resources");
            DropForeignKey("dbo.Planets", "Oxygen_Id", "dbo.Resources");
            DropForeignKey("dbo.Planets", "Energy_Id", "dbo.Resources");
            DropIndex("dbo.Planets", new[] { "SolarSystem_Id" });
            DropIndex("dbo.Planets", new[] { "Uranium_Id" });
            DropIndex("dbo.Planets", new[] { "Steel_Id" });
            DropIndex("dbo.Planets", new[] { "Oxygen_Id" });
            DropIndex("dbo.Planets", new[] { "Energy_Id" });
            DropTable("dbo.SolarSystems");
            DropTable("dbo.Resources");
            DropTable("dbo.Planets");
        }
    }
}
