namespace TestProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMainDbStructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "GroupId" });
            AddColumn("dbo.Curators", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Groups", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "IsStependint", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Groups", "CuratorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Groups", "CuratorId");
            CreateIndex("dbo.Students", "GroupId");
            AddForeignKey("dbo.Groups", "CuratorId", "dbo.Curators", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "ReceivesScholarship");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ReceivesScholarship", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "CuratorId", "dbo.Curators");
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "CuratorId" });
            AlterColumn("dbo.Students", "GroupId", c => c.Int());
            AlterColumn("dbo.Groups", "CuratorId", c => c.Int());
            DropColumn("dbo.Students", "IsDeleted");
            DropColumn("dbo.Students", "IsStependint");
            DropColumn("dbo.Groups", "IsDeleted");
            DropColumn("dbo.Curators", "IsDeleted");
            CreateIndex("dbo.Students", "GroupId");
            AddForeignKey("dbo.Students", "GroupId", "dbo.Groups", "Id");
        }
    }
}
