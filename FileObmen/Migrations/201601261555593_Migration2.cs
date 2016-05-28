namespace FileObmen.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Sha", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "Sha");
        }
    }
}
