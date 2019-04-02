namespace FestivalApp.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAboutMeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "AboutMe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "AboutMe");
        }
    }
}
