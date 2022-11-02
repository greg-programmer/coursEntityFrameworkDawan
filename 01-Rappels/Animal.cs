using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Rappels
{
    public abstract class Animal
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public void Identite()
        {
            Console.WriteLine("Animal....");
        }
    }
}
