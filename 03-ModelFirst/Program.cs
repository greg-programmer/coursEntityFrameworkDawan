using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ModelFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MyContextContainer();
            Blog b1 = new Blog() { Id=1,Nom="c#"};
            Blog b2 = new Blog() { Id=2,Nom="html"};

            context.BlogSet.Add(b1);
            context.BlogSet.Add(b2);
            context.SaveChanges();

            Post p1 = new Post() { Id = 1, Content = "content p1", BlogId = 1 };
            Post p2 = new Post() { Id = 2, Content = "content p2", BlogId = 2 };

            context.PostSet.Add(p1);
            context.PostSet.Add(p2);

            context.SaveChanges();

            Console.ReadKey();
        }
    }
}
