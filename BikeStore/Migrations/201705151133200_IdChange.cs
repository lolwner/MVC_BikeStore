namespace BikeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Goods", "Type_ID", "dbo.Types");
            DropIndex("dbo.Goods", new[] { "Type_ID" });
            DropPrimaryKey("dbo.Goods");
            DropPrimaryKey("dbo.Types");
            DropPrimaryKey("dbo.ListOfGoods");
            DropPrimaryKey("dbo.Manufacturers");
            DropPrimaryKey("dbo.Orders");
            AddColumn("dbo.Goods", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Goods", "ManufacturerId", c => c.String(nullable: false));
            AddColumn("dbo.Goods", "TypeId", c => c.String(nullable: false));
            AddColumn("dbo.Goods", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Types", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Types", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ListOfGoods", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ListOfGoods", "OrderId", c => c.String(nullable: false));
            AddColumn("dbo.ListOfGoods", "GoodId", c => c.String(nullable: false));
            AddColumn("dbo.ListOfGoods", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Manufacturers", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Manufacturers", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Orders", "ListId", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "ClientId", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ListOfGoods", "Amount", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Goods", "Id");
            AddPrimaryKey("dbo.Types", "Id");
            AddPrimaryKey("dbo.ListOfGoods", "Id");
            AddPrimaryKey("dbo.Manufacturers", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            DropColumn("dbo.Goods", "Good_ID");
            DropColumn("dbo.Goods", "Manufacturer_ID");
            DropColumn("dbo.Goods", "Type_ID");
            DropColumn("dbo.Types", "Type_ID");
            DropColumn("dbo.ListOfGoods", "List_ID");
            DropColumn("dbo.ListOfGoods", "Order_ID");
            DropColumn("dbo.ListOfGoods", "Good_ID");
            DropColumn("dbo.Manufacturers", "Manufacturer_ID");
            DropColumn("dbo.Orders", "Order_ID");
            DropColumn("dbo.Orders", "List_ID");
            DropColumn("dbo.Orders", "Client_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Client_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "List_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Order_ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Manufacturers", "Manufacturer_ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ListOfGoods", "Good_ID", c => c.Int(nullable: false));
            AddColumn("dbo.ListOfGoods", "Order_ID", c => c.Int(nullable: false));
            AddColumn("dbo.ListOfGoods", "List_ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Types", "Type_ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Goods", "Type_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Goods", "Manufacturer_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Goods", "Good_ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Manufacturers");
            DropPrimaryKey("dbo.ListOfGoods");
            DropPrimaryKey("dbo.Types");
            DropPrimaryKey("dbo.Goods");
            AlterColumn("dbo.ListOfGoods", "Amount", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "CreationDate");
            DropColumn("dbo.Orders", "ClientId");
            DropColumn("dbo.Orders", "ListId");
            DropColumn("dbo.Orders", "Id");
            DropColumn("dbo.Manufacturers", "CreationDate");
            DropColumn("dbo.Manufacturers", "Id");
            DropColumn("dbo.ListOfGoods", "CreationDate");
            DropColumn("dbo.ListOfGoods", "GoodId");
            DropColumn("dbo.ListOfGoods", "OrderId");
            DropColumn("dbo.ListOfGoods", "Id");
            DropColumn("dbo.Types", "CreationDate");
            DropColumn("dbo.Types", "Id");
            DropColumn("dbo.Goods", "CreationDate");
            DropColumn("dbo.Goods", "TypeId");
            DropColumn("dbo.Goods", "ManufacturerId");
            DropColumn("dbo.Goods", "Id");
            AddPrimaryKey("dbo.Orders", "Order_ID");
            AddPrimaryKey("dbo.Manufacturers", "Manufacturer_ID");
            AddPrimaryKey("dbo.ListOfGoods", "List_ID");
            AddPrimaryKey("dbo.Types", "Type_ID");
            AddPrimaryKey("dbo.Goods", "Good_ID");
            CreateIndex("dbo.Goods", "Type_ID");
            AddForeignKey("dbo.Goods", "Type_ID", "dbo.Types", "Type_ID", cascadeDelete: true);
        }
    }
}
