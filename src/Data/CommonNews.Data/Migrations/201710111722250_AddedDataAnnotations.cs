namespace CommonNews.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedDataAnnotations : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false, maxLength: 1024));
            this.AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 128));
            this.AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false, maxLength: 2500));
            this.AlterColumn("dbo.PostCategories", "Name", c => c.String(nullable: false, maxLength: 128));
        }

        public override void Down()
        {
            this.AlterColumn("dbo.PostCategories", "Name", c => c.String());
            this.AlterColumn("dbo.Posts", "Content", c => c.String());
            this.AlterColumn("dbo.Posts", "Title", c => c.String());
            this.AlterColumn("dbo.Comments", "Content", c => c.String());
        }
    }
}
