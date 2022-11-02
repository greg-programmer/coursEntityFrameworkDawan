using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ContraintesRelationsWithAnnotations
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }

        [ForeignKey("Author")] //permet de personnaliser le nom de la colonne de jointue entre les 2 tables
        public int AuthorId { get; set; }
        public List<Tag> Tags { get; set; }
        

        public Course()
        {
            Tags = new List<Tag>();
        }
    }
}
