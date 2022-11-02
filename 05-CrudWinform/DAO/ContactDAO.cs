using _05_CrudWinform.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CrudWinform.DAO
{
    public class ContactDAO : IContact
    {
        private MyContext context = new MyContext();
        public void Delete(int id)
        {
            Contact c = context.Contacts.Find(id);
            if (c != null)
            {
                context.Contacts.Remove(c);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Contact introuvable");
            }
        }

        public List<Contact> FindByKey(string key)
        {
            return context.Contacts.AsNoTracking().Where(c => c.Nom.Contains(key) || c.Prenom.Contains(key) ).ToList();
        }

        public List<Contact> GetAll()
        {
            return context.Contacts.AsNoTracking().ToList(); //AsNotracking : renvoie la liste des contacts sans les sauvegarder dans la cache du context
        }

        public Contact GetById(int id)
        {
            //id est unique: on ne peut avoir qu'un seul contact avec cet id: SingleOrDefault
            //nom n'est pas unique en BD: pour récupérer un contact via son nom: FirstOrDefault
            //return context.Contacts.AsNoTracking().FirstOrDefault(c => c.Nom == nom);
            return context.Contacts.AsNoTracking().SingleOrDefault(c => c.Id == id);
        }

        public void Insert(Contact c)
        {
            context.Contacts.Add(c);
            context.SaveChanges();
        }

        public void Update(Contact c)
        {
            Contact contactDB = context.Contacts.Find(c.Id); // etat = unchanged

            if(contactDB != null)
            {

                //context.Contacts.Attach(c); //etat unchanged
                //context.Entry(c).State = EntityState.Modified;
               // context.SaveChanges(); // exécution de la commande sql update

                contactDB.Nom = c.Nom;
                contactDB.Prenom = c.Prenom; // etat = Modified
                context.SaveChanges(); // exécution de la commande sql update
            }
            else
            {
                throw new Exception("Contact introuvable");
            }
        }
    }
}
