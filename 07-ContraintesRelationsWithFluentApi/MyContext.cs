using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace _07_ContraintesRelationsWithFluentApi
{
    public class MyContext : DbContext
    {
        
        public MyContext()
            : base("name=MyContext")
        {

            //Afficher les logs: - les requêtes SQL
            Database.Log = (str) => Debug.WriteLine(str);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Cover> Covers { get; set; }



        //Fluent Api: redéfinir la méthode OnModelCreating définie dans la classe DbContext

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Course: contraintes + relations

            modelBuilder.Entity<Course>()
                .ToTable("t_course");

            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);
            //Author

            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            //OneToMany: Author - Course - on peut exprimer cette relation dans les 2 sens - soit en partant de classe Course ou la classe Author

            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(true);

            /*  modelBuilder.Entity<Author>()
                  .HasMany(a => a.Courses)
                  .WithRequired(c => c.Author)
                  .HasForeignKey(c => c.AuthorId)
                  .WillCascadeOnDelete(true);*/

            //ManyToMany: Course - tag - on peut exprimer cette relation dans les 2 sens - partir de la classe Course ou la classe Tag

            modelBuilder.Entity<Course>()
                .HasMany(a => a.Tags)
                .WithMany(t => t.Courses)
                .Map(m =>
                {
                    m.ToTable("CourseTag")
                    .MapLeftKey("CourseId")
                    .MapRightKey("TagId");

                });

            /*   modelBuilder.Entity<Tag>()
                   .HasMany(a => a.Courses)
                   .WithMany(c => c.Tags)
                   .Map(m =>
                   {
                       m.ToTable("TagCourse")
                       .MapLeftKey("TagId")
                       .MapRightKey("CourseId");

                   });*/

            //Avec des annotations on ne pouvait o gérer que le one to zero or one
            //Via la Fluent Api on peut gérer le one to zero or one, comme on peut gérer le one to one

            //OneToOne: Course - Cover

            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Cover)
                .WithRequiredPrincipal(cv => cv.Course)
                .WillCascadeOnDelete(true);


            base.OnModelCreating(modelBuilder);
        }


    }
    /* Dans la pratique:
     * les contraintes sont gérées via annotations
     * les relations il est recommandé de les gérer via la Fluent Api
     */
    
}