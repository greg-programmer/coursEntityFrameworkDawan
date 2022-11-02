namespace _06_ContraintesRelationsWithAnnotations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ontToneCourseCover : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Covers", "CourseId", "dbo.Courses");
            DropIndex("dbo.Covers", new[] { "CourseId" });
            DropTable("dbo.Covers");
        }
    }
}
