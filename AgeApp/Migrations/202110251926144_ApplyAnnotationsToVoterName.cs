namespace AgeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToVoterName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voters", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voters", "Name", c => c.String());
        }
    }
}
