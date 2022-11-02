using System;
using System.Data.Entity;
using System.Linq;

namespace _06_ContraintesRelationsWithAnnotations
{
    public class MyContext : DbContext
    {
      
        public MyContext()
            : base("name=MyContext")
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Cover> Covers { get; set; }
    }

   
}