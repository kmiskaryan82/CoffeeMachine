namespace CoffeeMachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coffees",
                c => new
                    {
                        CoffeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Int(nullable: false),
                        WaterCount = c.Double(nullable: false),
                        CoffeeCount = c.Double(nullable: false),
                        SugarCount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CoffeeId);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceID = c.Int(nullable: false, identity: true),
                        ResourceName = c.String(),
                        Count = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Resources");
            DropTable("dbo.Coffees");
        }
    }
}
