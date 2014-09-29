namespace SCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersinroles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.webpages_Membership");
            DropForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.webpages_Roles");
            DropIndex("dbo.webpages_UsersInRoles", new[] { "UserId" });
            DropIndex("dbo.webpages_UsersInRoles", new[] { "RoleId" });
            CreateTable(
                "dbo.webpages_UsersInRoles2",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.webpages_Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.webpages_Membership", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            DropTable("dbo.webpages_UsersInRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.webpages_UsersInRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            DropIndex("dbo.webpages_UsersInRoles2", new[] { "UserId" });
            DropIndex("dbo.webpages_UsersInRoles2", new[] { "RoleId" });
            DropForeignKey("dbo.webpages_UsersInRoles2", "UserId", "dbo.webpages_Membership");
            DropForeignKey("dbo.webpages_UsersInRoles2", "RoleId", "dbo.webpages_Roles");
            DropTable("dbo.webpages_UsersInRoles2");
            CreateIndex("dbo.webpages_UsersInRoles", "RoleId");
            CreateIndex("dbo.webpages_UsersInRoles", "UserId");
            AddForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.webpages_Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.webpages_Membership", "UserId", cascadeDelete: true);
        }
    }
}
