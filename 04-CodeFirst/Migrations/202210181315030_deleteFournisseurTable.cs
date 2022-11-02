namespace _04_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteFournisseurTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Fournisseurs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
