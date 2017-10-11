namespace CommonNews.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedModels : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Author_Id = c.String(maxLength: 128),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Author_Id)
                .Index(t => t.Post_Id);

            this.CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Author_Id = c.String(maxLength: 128),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.PostCategories", t => t.Category_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Author_Id)
                .Index(t => t.Category_Id);

            this.CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);

            this.CreateIndex("dbo.AspNetUsers", "IsDeleted");
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            this.DropForeignKey("dbo.Posts", "Category_Id", "dbo.PostCategories");
            this.DropForeignKey("dbo.Posts", "Author_Id", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            this.DropIndex("dbo.PostCategories", new[] { "IsDeleted" });
            this.DropIndex("dbo.Posts", new[] { "Category_Id" });
            this.DropIndex("dbo.Posts", new[] { "Author_Id" });
            this.DropIndex("dbo.Posts", new[] { "IsDeleted" });
            this.DropIndex("dbo.Comments", new[] { "Post_Id" });
            this.DropIndex("dbo.Comments", new[] { "Author_Id" });
            this.DropIndex("dbo.Comments", new[] { "IsDeleted" });
            this.DropIndex("dbo.AspNetUsers", new[] { "IsDeleted" });
            this.DropTable("dbo.PostCategories");
            this.DropTable("dbo.Posts");
            this.DropTable("dbo.Comments");
        }
    }
}
