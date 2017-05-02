namespace BikeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyRemoved : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Good_ID = c.Int(nullable: false, identity: true),
                        Manufacturer_ID = c.Int(nullable: false),
                        Type_ID = c.Int(nullable: false),
                        Description = c.String(maxLength: 250),
                        Price = c.Double(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Good_ID)
                .ForeignKey("dbo.Types", t => t.Type_ID, cascadeDelete: true)
                .Index(t => t.Type_ID);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Type_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Type_ID);
            
            CreateTable(
                "dbo.ListOfGoods",
                c => new
                    {
                        List_ID = c.Int(nullable: false, identity: true),
                        Order_ID = c.Int(nullable: false),
                        Good_ID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.List_ID);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Manufacturer_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Manufacturer_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Order_ID = c.Int(nullable: false, identity: true),
                        List_ID = c.Int(nullable: false),
                        Client_ID = c.Int(nullable: false),
                        Summary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Order_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goods", "Type_ID", "dbo.Types");
            DropIndex("dbo.Goods", new[] { "Type_ID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.ListOfGoods");
            DropTable("dbo.Types");
            DropTable("dbo.Goods");
        }
    }
}
