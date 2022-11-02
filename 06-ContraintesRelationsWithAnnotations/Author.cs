using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ContraintesRelationsWithAnnotations
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; } //les attributs de type collection doivent être initialiser dans le constructeur

        public Author()
        {
            Courses = new List<Course>();
        }
    }
}
