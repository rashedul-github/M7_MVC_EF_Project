namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(),
                        ProjectId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                        WorkCarriedOut = c.String(nullable: false, maxLength: 50),
                        EstimatedCost = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false, maxLength: 40),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Contents", "ClientId", "dbo.Clients");
            DropIndex("dbo.Projects", new[] { "ClientId" });
            DropIndex("dbo.Contents", new[] { "ProjectId" });
            DropIndex("dbo.Contents", new[] { "ClientId" });
            DropTable("dbo.Projects");
            DropTable("dbo.Contents");
            DropTable("dbo.Clients");
        }
    }
}
