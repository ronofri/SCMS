namespace SCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersInRolesFix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.webpages_UsersInRoles2", newName: "webpages_UsersInRoles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.webpages_UsersInRoles", newName: "webpages_UsersInRoles2");
        }
    }
}
