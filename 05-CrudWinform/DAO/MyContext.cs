using _05_CrudWinform.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace _05_CrudWinform.DAO
{
    public class MyContext : DbContext
    {
        
        public MyContext()
            : base("name=MyContext")
        {
        }

        public DbSet<Contact> Contacts { get; set; }

    }

   
}