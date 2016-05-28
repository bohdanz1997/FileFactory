namespace FileObmen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvatarPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AvatarPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AvatarPath");
        }
    }
}
