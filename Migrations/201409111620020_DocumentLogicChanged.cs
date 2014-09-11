namespace SCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentLogicChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Document", "File");
            DropColumn("dbo.Document", "Thumbnail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Document", "Thumbnail", c => c.String());
            AddColumn("dbo.Document", "File", c => c.String());
        }
    }
}
