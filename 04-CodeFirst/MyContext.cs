using System;
using System.Data.Entity;
using System.Linq;

namespace _04_CodeFirst
{
    public class MyContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « MyContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « _04_CodeFirst.MyContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « MyContext » dans le fichier de configuration de l'application.
        public MyContext()
            : base("name=MyContext")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Contact> Contacts { get; set; }

     
        //public DbSet<Fournisseur> Fournisseurs { get; set; }


    }

 
}