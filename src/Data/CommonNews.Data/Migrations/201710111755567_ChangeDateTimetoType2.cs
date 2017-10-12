namespace CommonNews.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeDateTimetoType2 : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("dbo.Comments", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            this.AlterColumn("dbo.Comments", "ModifiedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            this.AlterColumn("dbo.Comments", "DeletedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            this.AlterColumn("dbo.Posts", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            this.AlterColumn("dbo.Posts", "ModifiedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            this.AlterColumn("dbo.Posts", "DeletedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            this.AlterColumn("dbo.PostCategories", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            this.AlterColumn("dbo.PostCategories", "ModifiedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            this.AlterColumn("dbo.PostCategories", "DeletedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }

        public override void Down()
        {
            this.AlterColumn("dbo.PostCategories", "DeletedOn", c => c.DateTime());
            this.AlterColumn("dbo.PostCategories", "ModifiedOn", c => c.DateTime());
            this.AlterColumn("dbo.PostCategories", "CreatedOn", c => c.DateTime(nullable: false));
            this.AlterColumn("dbo.Posts", "DeletedOn", c => c.DateTime());
            this.AlterColumn("dbo.Posts", "ModifiedOn", c => c.DateTime());
            this.AlterColumn("dbo.Posts", "CreatedOn", c => c.DateTime(nullable: false));
            this.AlterColumn("dbo.Comments", "DeletedOn", c => c.DateTime());
            this.AlterColumn("dbo.Comments", "ModifiedOn", c => c.DateTime());
            this.AlterColumn("dbo.Comments", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
