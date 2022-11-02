using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CrudWinform.Models
{

   
    public class Contact
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }

        public Contact(int id, string nom, string prenom)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
        }

        public Contact(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        public Contact()
        {
        }

        public override string ToString()
        {
            return $"Nom: {Nom} - Prénom: {Prenom}";
        }
    }
}
