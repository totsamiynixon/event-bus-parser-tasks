namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagsCounterTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackingCode = c.String(nullable: false, maxLength: 450),
                        Url = c.String(),
                        Status = c.Int(nullable: false),
                        Result = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TrackingCode);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TagsCounterTasks", new[] { "TrackingCode" });
            DropTable("dbo.TagsCounterTasks");
        }
    }
}
