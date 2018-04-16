namespace TestProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedPropertyIsDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Curators", "IsDeleted");
            DropColumn("dbo.Groups", "IsDeleted");
            DropColumn("dbo.Students", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Groups", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Curators", "IsDeleted", c => c.Boolean(nullable: false));
        }
    }
}
