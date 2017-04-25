namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'16cbdfb4-ae33-43ce-b28b-0dae90f7d5ca', N'admin@jimmycarson.com', 0, N'AFX2hchVSGZcHHA1Y0m3pxN/2m5kILZJIyGIoh8PWe45ESnL9FapaedG7FVGFdFgsg==', N'4879efd4-5912-4ee1-b004-9a9f63bade4c', NULL, 0, 0, NULL, 1, 0, N'admin@jimmycarson.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5ff14437-6635-4853-9d95-19aad9585f86', N'guest@jimmycarson.com', 0, N'AJ3VWmA+TezbB05B1HkADqz1JMEm3pkYUrdNOZv1HmOjcbry1eOvbidQg9Gsqcqngw==', N'9296766c-5381-4acc-8362-1fd17bba2c7c', NULL, 0, 0, NULL, 1, 0, N'guest@jimmycarson.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3b0f9cdf-9f39-48cb-9d53-5c390a6180db', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'16cbdfb4-ae33-43ce-b28b-0dae90f7d5ca', N'3b0f9cdf-9f39-48cb-9d53-5c390a6180db')
");
        }
        
        public override void Down()
        {
        }
    }
}
