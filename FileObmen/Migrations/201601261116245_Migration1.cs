namespace FileObmen.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Password", c => c.String());
            AddColumn("dbo.Files", "DeleteTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "DeleteTime");
            DropColumn("dbo.Files", "Password");
        }
    }
}
