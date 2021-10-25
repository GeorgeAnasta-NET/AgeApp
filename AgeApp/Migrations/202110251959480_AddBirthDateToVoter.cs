namespace AgeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateToVoter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Voters", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Voters", "BirthDate");
        }
    }
}
