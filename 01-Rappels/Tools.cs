using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Rappels
{
    public class Tools
    {
        /*
         * Une classe peut contenir 2 types de méthodes:
         * Méthode de classe (static): méthode qu'on peut appeler à partir de la classe Nom_Classe.N8m_Methode
         * Méthode d'instance: méthode qu'on peut appeler à partir d'une instance de la classe (on doit créer un objet de 
         * la classe )
         * 
         */


        //x est une variable de classe (gobale) - pas besoin de l'initialiser - elle possède une valeur par defaut
        int x;
        public static void Add()
        {

        }

        public void Afficher()
        {
            //y est variable locale qui doit être initialisée
            int y = 0;
            Console.WriteLine(y);
        }
    }
}
