namespace FileObmen.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Login = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                        Name = c.String(),
                        Type = c.String(),
                        UserId = c.Int(),
                        Description = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Files", new[] { "UserId" });
            DropForeignKey("dbo.Files", "UserId", "dbo.Users");
            DropTable("dbo.Files");
            DropTable("dbo.Users");
        }
    }
}
