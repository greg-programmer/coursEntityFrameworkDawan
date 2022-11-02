namespace _04_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFournisseurClasse : DbMigration
    {
        public override void Up()
        {
            CreateTable( "dbo.Fournisseurs", c => new { Id = c.Int(nullable: false, identity: true),Nom = c.String(),})
                .PrimaryKey(t => t.Id);

            //Insertion de données de test

            Sql("INSERT INTO Fournisseurs(Nom)VALUES('Carrefourt')");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fournisseurs");
        }
    }
}
