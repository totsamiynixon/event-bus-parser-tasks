namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexFix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TagsCounterTasks", new[] { "TrackingCode" });
            CreateIndex("dbo.TagsCounterTasks", "TrackingCode", unique: true, name: "TrackingCode");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TagsCounterTasks", "TrackingCode");
            CreateIndex("dbo.TagsCounterTasks", "TrackingCode");
        }
    }
}
