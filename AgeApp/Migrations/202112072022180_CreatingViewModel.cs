namespace AgeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ballots", "NumberInStock", c => c.Byte(nullable: false));
            DropColumn("dbo.Ballots", "NumberOfStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ballots", "NumberOfStock", c => c.Byte(nullable: false));
            DropColumn("dbo.Ballots", "NumberInStock");
        }
    }
}
