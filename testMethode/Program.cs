using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testMethode
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine(NombreDeChaine("fdfd"));
            Console.WriteLine(NombreDeMotParChaine("dsds"));
            Console.ReadKey();

        }
        public static int NombreDeChaine(string a)
        {
            return a.Length;
        }
        public static int NombreDeMotParChaine(string a)
        {
            string[]array = new string[a.Length];
            return array.Length;
        }
    }
}
