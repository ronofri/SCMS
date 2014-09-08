namespace SCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.POC", "DestinationPort_DestinationPortID", "dbo.DestinationPort");
            DropForeignKey("dbo.Customer", "defaultPort_DestinationPortID", "dbo.DestinationPort");
            DropForeignKey("dbo.Shipment", "POME_POMEID", "dbo.POME");
            DropForeignKey("dbo.BL", "Shipment_ShipmentID", "dbo.Shipment");
            DropIndex("dbo.POC", new[] { "DestinationPort_DestinationPortID" });
            DropIndex("dbo.Customer", new[] { "defaultPort_DestinationPortID" });
            DropIndex("dbo.Shipment", new[] { "POME_POMEID" });
            DropIndex("dbo.BL", new[] { "Shipment_ShipmentID" });
            AddColumn("dbo.Customer", "isEnterprise", c => c.Boolean(nullable: false));
            AddColumn("dbo.POME", "PricePerTon", c => c.Int(nullable: false));
            AddColumn("dbo.Shipment", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Shipment", "DestinationPort_DestinationPortID", c => c.Int());
            AddColumn("dbo.Shipment", "BL_BLID", c => c.Int());
            AddForeignKey("dbo.Shipment", "DestinationPort_DestinationPortID", "dbo.DestinationPort", "DestinationPortID");
            AddForeignKey("dbo.Shipment", "BL_BLID", "dbo.BL", "BLID");
            CreateIndex("dbo.Shipment", "DestinationPort_DestinationPortID");
            CreateIndex("dbo.Shipment", "BL_BLID");
            DropColumn("dbo.POC", "DestinationPort_DestinationPortID");
            DropColumn("dbo.Customer", "defaultPort_DestinationPortID");
            DropColumn("dbo.Shipment", "POME_POMEID");
            DropColumn("dbo.BL", "Amount");
            DropColumn("dbo.BL", "Shipment_ShipmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BL", "Shipment_ShipmentID", c => c.Int());
            AddColumn("dbo.BL", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Shipment", "POME_POMEID", c => c.Int());
            AddColumn("dbo.Customer", "defaultPort_DestinationPortID", c => c.Int());
            AddColumn("dbo.POC", "DestinationPort_DestinationPortID", c => c.Int());
            DropIndex("dbo.Shipment", new[] { "BL_BLID" });
            DropIndex("dbo.Shipment", new[] { "DestinationPort_DestinationPortID" });
            DropForeignKey("dbo.Shipment", "BL_BLID", "dbo.BL");
            DropForeignKey("dbo.Shipment", "DestinationPort_DestinationPortID", "dbo.DestinationPort");
            DropColumn("dbo.Shipment", "BL_BLID");
            DropColumn("dbo.Shipment", "DestinationPort_DestinationPortID");
            DropColumn("dbo.Shipment", "Status");
            DropColumn("dbo.POME", "PricePerTon");
            DropColumn("dbo.Customer", "isEnterprise");
            CreateIndex("dbo.BL", "Shipment_ShipmentID");
            CreateIndex("dbo.Shipment", "POME_POMEID");
            CreateIndex("dbo.Customer", "defaultPort_DestinationPortID");
            CreateIndex("dbo.POC", "DestinationPort_DestinationPortID");
            AddForeignKey("dbo.BL", "Shipment_ShipmentID", "dbo.Shipment", "ShipmentID");
            AddForeignKey("dbo.Shipment", "POME_POMEID", "dbo.POME", "POMEID");
            AddForeignKey("dbo.Customer", "defaultPort_DestinationPortID", "dbo.DestinationPort", "DestinationPortID");
            AddForeignKey("dbo.POC", "DestinationPort_DestinationPortID", "dbo.DestinationPort", "DestinationPortID");
        }
    }
}
