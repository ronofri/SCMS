namespace SCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePOME : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.POME", "POC_POCID", "dbo.POC");
            DropIndex("dbo.POME", new[] { "POC_POCID" });
            DropTable("dbo.POME");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.POME",
                c => new
                    {
                        POMEID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        PricePerTon = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        SpecialRequirements = c.String(),
                        POC_POCID = c.Int(),
                    })
                .PrimaryKey(t => t.POMEID);
            
            CreateIndex("dbo.POME", "POC_POCID");
            AddForeignKey("dbo.POME", "POC_POCID", "dbo.POC", "POCID");
        }
    }
}
