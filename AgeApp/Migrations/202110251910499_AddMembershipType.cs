namespace AgeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Voters", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Voters", "MembershipTypeId");
            AddForeignKey("dbo.Voters", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voters", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Voters", new[] { "MembershipTypeId" });
            DropColumn("dbo.Voters", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
