using _01_Rappels.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _01_Rappels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Homme h = new Homme();
            Femme femme = new Femme();
            Personne p = new Homme();

            Tools tools = new Tools();
            
            XmlSerializer xml = new XmlSerializer(typeof(Personne));
            Stream flux = new FileStream("c:\\test", FileMode.Create);
            xml.Serialize(flux, femme);

            Produit produit = new Produit(); // id = 0   - nom = null

            Chat c = new Chat();
            Animal a  = new Chien();
            Animal a2 = new Chat();
            Animal a3 = new Chien();

//Un objet Animal peut prendre plusieurs formes
//Le polymorphisme est une conséquence de l'héritage. Le fait qu'un objet parent puisse prendre la forme de tous les objets enfants
            
            int[] entiers = new int[2];
            entiers[0] = 10;
            entiers[1] = 20;

            Animal[] animaux = new Animal[3];
            animaux[0] = new Chien();
            animaux[1] = new Chat();
            animaux[2] = new Chien();

            Identite(new Chien());
            Identite(new Chat());
            Identite(new Chien());

            IPliable pp = new Table();

            Test(new Table());

            IPliable t1 = new Table();

        }

        public static void Identite(Animal a)
        {

        }

        public static void Test(IPliable i)
        {

        }
    }
}
