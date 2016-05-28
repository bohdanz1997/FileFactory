namespace FileObmen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "RoleId", c => c.Int());
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
            CreateIndex("dbo.Users", "RoleId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropColumn("dbo.Users", "RoleId");
            DropTable("dbo.Roles");
        }
    }
}
