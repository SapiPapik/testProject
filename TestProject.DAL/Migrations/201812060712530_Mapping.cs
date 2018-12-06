namespace TestProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "CuratorId", "dbo.Curators");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropPrimaryKey("dbo.Curators");
            DropPrimaryKey("dbo.Groups");
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Curators", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Groups", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Students", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Curators", "Id");
            AddPrimaryKey("dbo.Groups", "Id");
            AddPrimaryKey("dbo.Students", "Id");
            AddForeignKey("dbo.Groups", "CuratorId", "dbo.Curators", "Id");
            AddForeignKey("dbo.Students", "GroupId", "dbo.Groups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "CuratorId", "dbo.Curators");
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.Groups");
            DropPrimaryKey("dbo.Curators");
            AlterColumn("dbo.Students", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Groups", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Curators", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Students", "Id");
            AddPrimaryKey("dbo.Groups", "Id");
            AddPrimaryKey("dbo.Curators", "Id");
            AddForeignKey("dbo.Students", "GroupId", "dbo.Groups", "Id");
            AddForeignKey("dbo.Groups", "CuratorId", "dbo.Curators", "Id");
        }
    }
}
