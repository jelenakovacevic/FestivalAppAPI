namespace FestivalApp.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFestivalRatingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFestivalRating",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FestivalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.FestivalId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Festival", t => t.FestivalId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FestivalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFestivalRating", "FestivalId", "dbo.Festival");
            DropForeignKey("dbo.UserFestivalRating", "UserId", "dbo.User");
            DropIndex("dbo.UserFestivalRating", new[] { "FestivalId" });
            DropIndex("dbo.UserFestivalRating", new[] { "UserId" });
            DropTable("dbo.UserFestivalRating");
        }
    }
}
