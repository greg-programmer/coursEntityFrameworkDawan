namespace _04_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumnNomToNameInFournisseurClasse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fournisseurs", "Name", c => c.String());
            Sql("UPDATE Fournisseurs SET Name=Nom");
            DropColumn("dbo.Fournisseurs", "Nom");

           // RenameColumn("dbo.Fournisseurs", "Name", "Nom"); cette méthode fait la mm que 3 lignes précedentes
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fournisseurs", "Nom", c => c.String());
            Sql("UPDATE Fournisseurs SET Nom=Name");
            DropColumn("dbo.Fournisseurs", "Name");
        }
    }
}
