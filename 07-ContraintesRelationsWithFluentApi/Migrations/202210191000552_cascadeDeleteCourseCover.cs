namespace _07_ContraintesRelationsWithFluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadeDeleteCourseCover : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Covers", "Id", "dbo.t_course");
            AddForeignKey("dbo.Covers", "Id", "dbo.t_course", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Covers", "Id", "dbo.t_course");
            AddForeignKey("dbo.Covers", "Id", "dbo.t_course", "Id");
        }
    }
}
