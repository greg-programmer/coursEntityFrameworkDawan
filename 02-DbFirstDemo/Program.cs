using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DbFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employe e = new Employe() { nom = "dawan", prenom = "prenom" };

            dbfirstEntities context = new dbfirstEntities();
            //context.Employe.Add(e); //etat de e dans le context = added

            /*
             * SaveChanges scan le context et vérifie l'état des objets chargés dessus
             * et selon leur état elle génère la commande sql à exécuter
             * Added
             * Deleted
             * Modified
             * 
             */

            Console.WriteLine("Added state: "+context.Entry(e).State);

            //context.SaveChanges();

            Employe e1 = context.Employe.Find(1);

            Console.WriteLine("Find state: "+context.Entry(e1).State); //unchanged

            context.Entry(e1).State = EntityState.Added;  
            /*
            e1.prenom = "new prenom";

            Console.WriteLine("e1 state après modif du prénom: "+context.Entry(e1).State);*/

            //context.SaveChanges();

            context.Employe.Remove(e1);

            Console.WriteLine("Remove state: " + context.Entry(e1).State); //deleted

            context.SaveChanges(); //commande delete de sql qui sera exécutée



            Console.ReadLine();
        }
    }
}/*
  * Approche DB First: partir d'une BD existante
  * Toute modification de la BD implique une MAJ du model
  * 
  */
