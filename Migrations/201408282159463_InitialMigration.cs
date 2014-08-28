namespace SCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.POC",
                c => new
                    {
                        POCID = c.Int(nullable: false, identity: true),
                        AmountTotal = c.Int(nullable: false),
                        PricePerTon = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        Comments = c.String(),
                        CreationDate = c.DateTime(),
                        Customer_CustomerID = c.Int(),
                        DestinationPort_DestinationPortID = c.Int(),
                        Product_ProductID = c.Int(),
                        CustomerIncoterm_IncotermID = c.Int(),
                    })
                .PrimaryKey(t => t.POCID)
                .ForeignKey("dbo.Customer", t => t.Customer_CustomerID)
                .ForeignKey("dbo.DestinationPort", t => t.DestinationPort_DestinationPortID)
                .ForeignKey("dbo.Product", t => t.Product_ProductID)
                .ForeignKey("dbo.Incoterm", t => t.CustomerIncoterm_IncotermID)
                .Index(t => t.Customer_CustomerID)
                .Index(t => t.DestinationPort_DestinationPortID)
                .Index(t => t.Product_ProductID)
                .Index(t => t.CustomerIncoterm_IncotermID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ContactInfo = c.String(),
                        defaultPort_DestinationPortID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.DestinationPort", t => t.defaultPort_DestinationPortID)
                .Index(t => t.defaultPort_DestinationPortID);
            
            CreateTable(
                "dbo.DestinationPort",
                c => new
                    {
                        DestinationPortID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ContactInfo = c.String(),
                    })
                .PrimaryKey(t => t.DestinationPortID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alloy_AlloyID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Alloy", t => t.Alloy_AlloyID)
                .Index(t => t.Alloy_AlloyID);
            
            CreateTable(
                "dbo.Alloy",
                c => new
                    {
                        AlloyID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hardness = c.Int(nullable: false),
                        Breakage = c.Int(nullable: false),
                        Material = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlloyID);
            
            CreateTable(
                "dbo.Incoterm",
                c => new
                    {
                        IncotermID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IncotermID);
            
            CreateTable(
                "dbo.POME",
                c => new
                    {
                        POMEID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        SpecialRequirements = c.String(),
                        POC_POCID = c.Int(),
                    })
                .PrimaryKey(t => t.POMEID)
                .ForeignKey("dbo.POC", t => t.POC_POCID)
                .Index(t => t.POC_POCID);
            
            CreateTable(
                "dbo.Shipment",
                c => new
                    {
                        ShipmentID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        EstimatedTimeDeparture = c.DateTime(),
                        EstimatedTimeArrival = c.DateTime(),
                        ShipmentNumber = c.Int(nullable: false),
                        Schedule_ScheduleID = c.Int(),
                        POME_POMEID = c.Int(),
                    })
                .PrimaryKey(t => t.ShipmentID)
                .ForeignKey("dbo.Schedule", t => t.Schedule_ScheduleID)
                .ForeignKey("dbo.POME", t => t.POME_POMEID)
                .Index(t => t.Schedule_ScheduleID)
                .Index(t => t.POME_POMEID);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        POC_POCID = c.Int(),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.POC", t => t.POC_POCID)
                .Index(t => t.POC_POCID);
            
            CreateTable(
                "dbo.BL",
                c => new
                    {
                        BLID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        ShipName = c.String(),
                        Shipment_ShipmentID = c.Int(),
                    })
                .PrimaryKey(t => t.BLID)
                .ForeignKey("dbo.Shipment", t => t.Shipment_ShipmentID)
                .Index(t => t.Shipment_ShipmentID);
            
            CreateTable(
                "dbo.Container",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        BL_BLID = c.Int(),
                    })
                .PrimaryKey(t => t.ContainerID)
                .ForeignKey("dbo.BL", t => t.BL_BLID)
                .Index(t => t.BL_BLID);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        DocumentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        File = c.String(),
                        Thumbnail = c.String(),
                        UploadDate = c.DateTime(),
                        BL_BLID = c.Int(),
                    })
                .PrimaryKey(t => t.DocumentID)
                .ForeignKey("dbo.BL", t => t.BL_BLID)
                .Index(t => t.BL_BLID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Document", new[] { "BL_BLID" });
            DropIndex("dbo.Container", new[] { "BL_BLID" });
            DropIndex("dbo.BL", new[] { "Shipment_ShipmentID" });
            DropIndex("dbo.Schedule", new[] { "POC_POCID" });
            DropIndex("dbo.Shipment", new[] { "POME_POMEID" });
            DropIndex("dbo.Shipment", new[] { "Schedule_ScheduleID" });
            DropIndex("dbo.POME", new[] { "POC_POCID" });
            DropIndex("dbo.Product", new[] { "Alloy_AlloyID" });
            DropIndex("dbo.Customer", new[] { "defaultPort_DestinationPortID" });
            DropIndex("dbo.POC", new[] { "CustomerIncoterm_IncotermID" });
            DropIndex("dbo.POC", new[] { "Product_ProductID" });
            DropIndex("dbo.POC", new[] { "DestinationPort_DestinationPortID" });
            DropIndex("dbo.POC", new[] { "Customer_CustomerID" });
            DropForeignKey("dbo.Document", "BL_BLID", "dbo.BL");
            DropForeignKey("dbo.Container", "BL_BLID", "dbo.BL");
            DropForeignKey("dbo.BL", "Shipment_ShipmentID", "dbo.Shipment");
            DropForeignKey("dbo.Schedule", "POC_POCID", "dbo.POC");
            DropForeignKey("dbo.Shipment", "POME_POMEID", "dbo.POME");
            DropForeignKey("dbo.Shipment", "Schedule_ScheduleID", "dbo.Schedule");
            DropForeignKey("dbo.POME", "POC_POCID", "dbo.POC");
            DropForeignKey("dbo.Product", "Alloy_AlloyID", "dbo.Alloy");
            DropForeignKey("dbo.Customer", "defaultPort_DestinationPortID", "dbo.DestinationPort");
            DropForeignKey("dbo.POC", "CustomerIncoterm_IncotermID", "dbo.Incoterm");
            DropForeignKey("dbo.POC", "Product_ProductID", "dbo.Product");
            DropForeignKey("dbo.POC", "DestinationPort_DestinationPortID", "dbo.DestinationPort");
            DropForeignKey("dbo.POC", "Customer_CustomerID", "dbo.Customer");
            DropTable("dbo.Document");
            DropTable("dbo.Container");
            DropTable("dbo.BL");
            DropTable("dbo.Schedule");
            DropTable("dbo.Shipment");
            DropTable("dbo.POME");
            DropTable("dbo.Incoterm");
            DropTable("dbo.Alloy");
            DropTable("dbo.Product");
            DropTable("dbo.DestinationPort");
            DropTable("dbo.Customer");
            DropTable("dbo.POC");
        }
    }
}
