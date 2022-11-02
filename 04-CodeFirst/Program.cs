using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MyContext();
            Contact contact = new Contact { Nom = "nom", prenom = "prenom" }; //initialisateur automatique
            context.Contacts.Add(contact);
            context.SaveChanges();

            Console.ReadLine();

        }
    }
}
/*
 * Approche code first: avoir un contrôle total sur la BD via le code
 * 1- Vérifier que le projet est définie par defaut dans la solution
 * 2- Lancer la console du gestionnaire de package et vérifier que le projet est définit par defaut
 * 3- exécuter la commande: enable migrations (commande à exécuter qu'une seule fois)
 * 4-Une fois le model objet sauvegardé - créer une migration via la commande add-migration nom_migration
 *      
 * 5- Toute modification du model objet implique une migration (maj de la BD)
 *   Bonne pratique: faire des migrations pour des petites modifications.
 * 6- Pour faire un rollback vers une migration particulière, la commande:
 *    update-database -TargetMigration: addFournisseurClasse
 * 
 * 
 * 
 */