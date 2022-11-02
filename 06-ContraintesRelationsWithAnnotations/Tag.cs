using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ContraintesRelationsWithAnnotations
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

        public Tag()
        {
            Courses = new List<Course>();
        }
    }
}
