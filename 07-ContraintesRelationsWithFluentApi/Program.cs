using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ContraintesRelationsWithFluentApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MyContext();

            List<Author> authors = context.Authors.ToList();  //List accéssible en lecture/écriture           .

            IEnumerable<Author> authors2 = context.Authors.ToList(); //List en lecture seule

            #region "Chargement des associations"

            /*
             * Lazy Loading: chargement tardif ou chargement à la demande - mode par defaut utilisé par EF
             * Eager Loading: chargement immédiat - il suffit de définir les association comme étant virtual
             * 
             */

            //En mode Lazy: on utilise la méthode incluse (LINQ), pour inclure les associations au chargement

            Author aut1 = context.Authors.Include(a => a.Courses).SingleOrDefault(a => a.Id == 1);

            Console.WriteLine(aut1.Name);



            Console.WriteLine("Courses associés: ");

            foreach (Course c in aut1.Courses)
            {
                Console.WriteLine(c.Name);
            }


            //Un course possède un seul Author - chargement immédiat par defaut
            //Un course possède une LIst de Tag - chargement à la demande par defaut

            Course course1 = context.Courses.Include(c => c.Tags).SingleOrDefault(c => c.Id == 1);


            Console.WriteLine("Course name: " + course1.Name);
            Console.WriteLine("Author: " + course1.Author.Name);

            Console.WriteLine("Tags de Course1:");

            foreach (Tag t in course1.Tags)
            {
                Console.WriteLine(t.Name);
            }

            #endregion

            #region "LINQ"

            /*
             * LINQ: Langage Integrated Query propre microsoft - permet d'interroger n'importe quelle source de connées: BD, fichier, List....;
             * 
             */

            var allCourses = context.Courses.ToList();

            //Afficher uniquement les courses dont le prix > 20

            //Approche impérative: on doit dire au compilateur ce qu'il doit faire et comment le faire

            Console.WriteLine("Approche impérative:");
            foreach (Course c in allCourses)
            {
                if (c.FullPrice > 20)
                {
                    Console.WriteLine(c.Name);
                }
            }

            //Approche déclarative: déclarer au compilateur ce qu'on souhaite sans lui dire commenet le faire

            Console.WriteLine("Approche déclarative:");

            allCourses.Where(c => c.FullPrice > 20).ToList().ForEach(c => Console.WriteLine(c.Name));

            Func<int, int, int> Somme = (x, y) => x + y;
            Action<string> AfficherChaine = (str) => Console.WriteLine(str);
            AfficherChaine("qsdqsdqsdqsd");
            Predicate<Course> VerifPrix = (cr) => cr.FullPrice > 20;


            int resultat = Somme(15, 30);
            Console.WriteLine(resultat);
            /*
             * Expression Lambda: méthode anonyme - syntaxe qui permet de déclarer des méthode
             * 
             */

            /*
             * 2 façons d'utiliser LINQ: sa syntaxe - ses méthodes (chainage de méthode - approche déclarative)
             */

            //Syntaxe de LINQ: approche qui convient aux DEV Sql

            Console.WriteLine("*****************LINQ WITH SYNTAXE************************");

            //Restriction: Author dont id = 1



            var query1 = from a in context.Authors
                         where a.Id == 1
                         select a;

            foreach (var item in query1)
            {
                Console.WriteLine(item.Name);
            }

            //Order: la liste des coure de author1 orderby courseName

            var query2 = from c in context.Courses
                         where c.AuthorId == 1
                         orderby c.Name
                         select c;

            foreach (var item in query2)
            {
                Console.WriteLine(item.Name);
            }

            //Projection: Nom author1 + Nom des courses associés

            var query3 = from c in context.Courses
                         where c.AuthorId == 1

                         //Option1: créer une classe qui va contenir les 2 besoins (nom author + nom course) 
                         // select new CourseAuthor { CourseName = c.Name, AuthorName = c.Author.Name }; 


                         //Option2: utiliser des objets anonymes
                         select new { CourseName = c.Name, AuthorName = c.Author.Name };
            foreach (var item in query3)
            {
                Console.WriteLine($"Course Name: {item.CourseName} - Author Name: {item.AuthorName}");
            }

            //GroupBy: la liste des Courses regroupé par prix

            var query4 = from c in context.Courses
                         group c by c.FullPrice
                            into g
                         select g; //g: contient la liste des groupes

            foreach (var group in query4)
            {
                //Afficher la clé de groupage (FullPrice)
                Console.WriteLine("Prix: " + group.Key);
                foreach (var cr in group)
                {
                    Console.WriteLine($"\t{cr.Name}\n");
                }
            }

            //Jointure: inner join, Group join , cross join

            //inner join: nom du cour + nom de auteur

            var query5 = from c in context.Courses
                         join a in context.Authors on c.AuthorId equals a.Id
                         select new { CourseName = c.Name, AuthorName = c.Author.Name };

            //Group Join: nom author + nombre de cours associé

            var query6 = from a in context.Authors
                         join c in context.Courses on a.Id equals c.AuthorId into g
                         select new { AuthorName = a.Name, nbCourses = g.Count() };

            //Cross Join: prendre chaque ligne de la table de gauche et chaque de la table de droite sans condition de jointure

            var query7 = from a in context.Authors
                         from c in context.Courses
                         select new { AuthorName = a.Name, CourseName = c.Name };


            Console.WriteLine("*****************LINQ WITH Chainage de Méthodes************************");

            //Restriction: author dont id = 1
            var author1 = context.Authors.Where(c => c.Id == 1);

            //Projection 
            //Order: la liste des coure de author1 orderby courseName

            /*var query2 = from c in context.Courses
                         where c.AuthorId == 1
                         orderby c.Name
                         select c;

            foreach (var item in query2)
            {
                Console.WriteLine(item.Name);
            }*/

            var courses1 = context.Courses.Where(c => c.Id == 1);

            context.Courses.GroupBy(c => c.Name);

            context.Courses.GroupJoin(context.Courses, a => a.Id, c => c.Id); ;

            #endregion

            Console.ReadKey();

        }

        //(d, c) => cw
        public static void Afficher(int d, Course c)
        {

        }

        //(x,y) => x+y;
        public static int Add(int x, int y)
        {
            return x + y;
        }
    }
}