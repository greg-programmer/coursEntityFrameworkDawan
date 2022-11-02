using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ContraintesRelationsWithFluentApi
{
    public class Cover
    {
        //1 -> 0,1
        /*
         * one to one
         * one to zero or one - on doit choisir la classe pricipale - c'est l'autre classe qui doit contenir la clé de jointure
         */
        public int Id { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
    }
}
