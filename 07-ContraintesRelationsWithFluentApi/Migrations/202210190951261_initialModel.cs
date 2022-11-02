namespace _07_ContraintesRelationsWithFluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        FullPrice = c.Single(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);

            CreateTable(
                "dbo.Covers",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_course", t => t.Id)
                .Index(t => t.Id);
                
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTag",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.TagId })
                .ForeignKey("dbo.t_course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTag", "TagId", "dbo.Tags");
            DropForeignKey("dbo.CourseTag", "CourseId", "dbo.t_course");
            DropForeignKey("dbo.Covers", "Id", "dbo.t_course");
            DropForeignKey("dbo.t_course", "AuthorId", "dbo.Authors");
            DropIndex("dbo.CourseTag", new[] { "TagId" });
            DropIndex("dbo.CourseTag", new[] { "CourseId" });
            DropIndex("dbo.Covers", new[] { "Id" });
            DropIndex("dbo.t_course", new[] { "AuthorId" });
            DropTable("dbo.CourseTag");
            DropTable("dbo.Tags");
            DropTable("dbo.Covers");
            DropTable("dbo.t_course");
            DropTable("dbo.Authors");
        }
    }
}
