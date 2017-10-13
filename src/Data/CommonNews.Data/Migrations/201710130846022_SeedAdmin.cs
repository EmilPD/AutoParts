namespace CommonNews.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedAdmin : DbMigration
    {
        public override void Up()
        {
            this.Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id],[IsDeleted],[DeletedOn],[CreatedOn],[ModifiedOn],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEndDateUtc],[LockoutEnabled],[AccessFailedCount],[UserName]) VALUES (N'712f0f37-94c8-495e-a0dc-94ff0ef441f9',0,NULL,'2017-10-11 23:23:05.947',NULL,N'info@telerikacademy.com',0,N'ACxD6jy6ImEPcZnCmwMvOuA1aO6SvkYNhMoX7JgevhTowVpHKlywg+Kpk4w185cBEA==',N'01be06f3-d3d3-45fa-a03a-21c64880b983',NULL,0,0,NULL,1,0,N'tele')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (1, N'Admin'), (2, N'User'), (3, N'Guest')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'712f0f37-94c8-495e-a0dc-94ff0ef441f9', 1)");
        }

        public override void Down()
        {
        }
    }
}
