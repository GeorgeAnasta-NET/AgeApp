namespace AgeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'114d7a74-0821-4dd0-b919-750e2bba22c8', N'admin@ageapp.com', 0, N'AP0dG+aNrdfy1O7a0qQntOEeNBwT1zSFIB6urgq3Gq+YjTTxH+2rSL+NrwVFetUE9w==', N'a6ebc7c7-d1b2-441b-b365-31c870b4a071', NULL, 0, 0, NULL, 1, 0, N'admin@ageapp.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'99e6cdb3-a352-47c6-b754-8936c30e1810', N'guest@ageapp.com', 0, N'ALOHZbrhcrAA1zBn+vidBJn4pYrKw7rK3WHrfDMABR+uwrp3NKaym5KwU+svk2G9cQ==', N'deb49c07-e7b8-486a-8aef-64c215be7240', NULL, 0, 0, NULL, 1, 0, N'guest@ageapp.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8b267cf6-28b2-4e0a-9919-1dfd80ae2e55', N'CanManageBallots')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'114d7a74-0821-4dd0-b919-750e2bba22c8', N'8b267cf6-28b2-4e0a-9919-1dfd80ae2e55')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
