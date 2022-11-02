using System;
using System.Data.Entity;
using System.Linq;

namespace _08_InitialiserDatabase
{
    public class MyContext : DbContext
    {
        //Ne pas faire dans un environnment PROD
        //Pratique pour tester les fonctionnalités d'une application
       
        public MyContext()
            : base("name=MyContext")
        {
            //Initialiser la BD
            Database.SetInitializer(new InitDB());
            Database.Initialize(true);
        }

        public DbSet<Contact> Contacts { get; set; }
    }

    
}