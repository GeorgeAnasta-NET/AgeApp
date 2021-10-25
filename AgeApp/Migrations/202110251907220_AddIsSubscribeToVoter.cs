namespace AgeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribeToVoter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Voters", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Voters", "IsSubscribedToNewsLetter");
        }
    }
}
