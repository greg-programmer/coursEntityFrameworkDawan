using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_InitialiserDatabase
{
    /*
     * DropCreateDatabaseAlways
     * DropCreateDatabaseIfModelChanges
     * CreateDatabaseIfNotExist
     */
    public class InitDB : DropCreateDatabaseAlways<MyContext>
    {
        public override void InitializeDatabase(MyContext context)
        {
            base.InitializeDatabase(context);
            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact { Id=1, Name="c1"});
            contacts.Add(new Contact { Id=2, Name="c2"});
            contacts.Add(new Contact { Id=3, Name="c3"});

            foreach (var item in contacts)
            {
                context.Contacts.Add(item);
            }

            context.SaveChanges();

        }
    }
}
