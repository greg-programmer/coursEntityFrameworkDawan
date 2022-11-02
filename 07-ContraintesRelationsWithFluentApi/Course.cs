using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ContraintesRelationsWithFluentApi
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; } // 1 objet: mode eager par defaut
        public int AuthorId { get; set; }
        public List<Tag> Tags { get; set; } //Collection: mode lazy par defaut

        public Cover Cover { get; set; } // optionnel

        public Course()
        {
            Tags = new List<Tag>();
        }
    }
}
