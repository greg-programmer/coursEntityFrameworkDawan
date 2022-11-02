using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_InitialiserDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MyContext();

            Console.WriteLine("Base de données initialisée.....................");
            Console.ReadLine();
        }
    }
}
/*
 * Pour initialiser une BD:
 * 
 * 1- Créer une classe qui permet de choisir une stratégie d'initialisation (voir la classe InitDB) + insertion de données
 * 2- Dans le constructeur du context, fournir cette classe via ces 2 instructions:
 * Database.SetInitializer(new InitDB());
   Database.Initialize(true);
 * 
 * 
 */