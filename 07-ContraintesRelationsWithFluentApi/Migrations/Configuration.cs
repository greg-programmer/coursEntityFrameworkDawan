namespace _07_ContraintesRelationsWithFluentApi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_07_ContraintesRelationsWithFluentApi.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_07_ContraintesRelationsWithFluentApi.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            #region "Tags"

            var tags = new Dictionary<string, Tag>
            {
                {"c#", new Tag{Id=1, Name = "c#"} },
                {"angular", new Tag{Id=2, Name ="angular"} },
                {"html", new Tag{Id=3, Name ="html"} }
            };

            foreach (var item in tags.Values)
            {
                context.Tags.AddOrUpdate(t => t.Id, item);
            }

            #endregion

            #region "Author"

            var authors = new List<Author>
            {
                new Author { Id = 1, Name ="Dawan"},
                new Author { Id = 2, Name ="Jehann"},
                new Author { Id = 3, Name ="Auth3"},
            };

            foreach (var item in authors)
            {
                context.Authors.AddOrUpdate(a => a.Id, item);
            }

            #endregion

            #region "Course"

            var courses = new List<Course>
            {
                new Course {
                    Id = 1,
                    Name = "c# basic",
                    AuthorId = 1,
                    FullPrice = 20,
                    Description = "Descr. pour c# basic",
                    Tags = new List<Tag>
                    {
                        tags["c#"]
                    }

                },
                 new Course {
                    Id = 2,
                    Name = "angular initiation",
                    AuthorId = 2,
                    FullPrice = 20,
                    Description = "Descr. pour angular",
                    Tags = new List<Tag>
                    {
                        tags["angular"]
                    }

                },
                  new Course {
                    Id = 3,
                    Name = "html débutant",
                    AuthorId = 3,
                    FullPrice = 30,
                    Description = "Descr. pour html",
                    Tags = new List<Tag>
                    {
                        tags["html"]
                    }

                },


            };

            foreach (var item in courses)
            {
                context.Courses.AddOrUpdate(c => c.Id, item);
            }
            #endregion
        }
    }
}
