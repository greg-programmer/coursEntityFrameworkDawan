using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Rappels.Models
{
    internal interface IPersonne
    {
        //pseudo classe abstraite qui ne contient que des signatures de méthodes
        List<Personne> getAll();
        void insert(Personne person);
        void delete(Personne person);
        void update(Personne person);
    }
}
